# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Project overview

`ApiSports.Sdk` is a .NET SDK that wraps the [api-sports.io](https://api-sports.io) HTTP APIs.
It is a multi-project solution (`api-sports.sln`) targeting `net8.0;net9.0;net10.0` (see `Directory.Build.props`) and is published as multiple NuGet packages — one per sport plus shared abstractions/core. Package versions live in `versions.props`.

Always read `AGENTS.md` before generating non-trivial code in this repo — it imposes hard constraints (no reflection-based serialization, no new architectural layers, no convenience overloads, etc.) that override generic .NET defaults.

## Build, test, run

```bash
dotnet restore
dotnet build -c Release --no-restore
dotnet test  -c Release --no-build           # all tests
dotnet test  tests/ApiSports.Sdk.Football.Tests --filter FullyQualifiedName~FootballSampleResponseTests
dotnet run   --project samples/SampleConsole # exercises the SDK against the live API (needs a real API key in Program.cs)
```

NuGet packing happens via `dotnet pack` per-project; release builds set `-p:UsePackageReferences=true` so each package consumes its siblings via NuGet rather than ProjectReference (see the conditional `ItemGroup`s in every sport `.csproj` and `.github/workflows/release.yaml`). Default local builds use ProjectReferences.

Releases are triggered by tags shaped `ApiSports.Sdk.<Package>/v<Version>` (`.github/workflows/release.yaml`). The PR workflow does build + test + dry-run pack on `dotnet 10.0.x`.

## Architecture

Strict, intentionally shallow hierarchy:

```
ApiSportsSdk                                 (entry point — holds options, creates per-sport HTTP clients)
 └─ ApiSportsHttpClient                      (one per sport — owns rate limiting + request pipeline)
     └─ SportClient (e.g. FootballClient)    (pure aggregator of domain clients; no logic)
         └─ Domain clients (Fixtures, Teams, …)
             └─ one method per endpoint, accepting a strongly typed Query object
```

Key files for the wiring:

- [src/ApiSports.Sdk.Core/ApiSportsSdk.cs](src/ApiSports.Sdk.Core/ApiSportsSdk.cs) — `Create(apiKey, …)` factory and `ForSport(sport)`.
- [src/ApiSports.Sdk.Core/ApiSportsClientFactory.cs](src/ApiSports.Sdk.Core/ApiSportsClientFactory.cs) — assembles the `HttpClient` pipeline: `ApiKeyHandler` → `RateLimitTrackingHandler` → `RateLimitEnforcementHandler` → `SocketsHttpHandler`, plus a parallel "status" client (no rate limiting) used by the pacing limiter.
- [src/ApiSports.Sdk.Core/ApiSportsHttpClient.cs](src/ApiSports.Sdk.Core/ApiSportsHttpClient.cs) — the only place where requests are issued/deserialized. Every domain client method routes through `http.GetAsync(path, query, JsonTypeInfo<…>, ct)`.
- [src/ApiSports.Sdk.Core/DefaultSportBaseUriResolver.cs](src/ApiSports.Sdk.Core/DefaultSportBaseUriResolver.cs) — maps `ApiSportsSport` enum values to the official per-sport base URIs (`v3.football.api-sports.io`, `v1.formula-1.api-sports.io`, …).

### Projects

- `ApiSports.Sdk.Abstractions` — public contracts (`IQueryString`, `ApiResponse<T>`, `IApiSportsLogger`, `IApiSportsRateLimiter`, `IRateLimitStateStore`, `ApiSportsClientOptions`, `RateLimitOptions`, `ApiSportsSport`, shared common DTOs). No HTTP, no JSON contexts.
- `ApiSports.Sdk.Core` — `HttpClient` pipeline, pacing rate limiter, `ApiSportsSdk` entry point, `ApiSportsApiException`. Generic across sports.
- `ApiSports.Sdk.Football`, `ApiSports.Sdk.Formula1` — sport modules. Each owns its `Clients/`, `QueryParams/`, `Models/`, and `Json/` (one `JsonSerializerContext` per domain client).
- `ApiSports.Sdk.Logging.Microsoft` — optional adapter mapping `IApiSportsLogger` onto `Microsoft.Extensions.Logging`.
- `samples/SampleConsole` — AOT-published smoke test (`<PublishAot>true</PublishAot>`).
- `tests/*` — xUnit with `xunit.skippablefact`; `YamlDotNet` is used to consume `api-specs/**/openapi.yaml` in contract tests.

### Adding an endpoint (the only supported flow)

This is the pattern to imitate. Do not invent variants.

1. Add or extend a query class in `QueryParams/` implementing `IQueryString`. Map every parameter explicitly inside `ToQueryParameters()` — date as `yyyy-MM-dd`, booleans/numbers as `.ToString()`, optionality via nullability, mandatory via `required`. No validation, no cross-field logic. See [src/ApiSports.Sdk.Football/QueryParams/FixturesQuery.cs](src/ApiSports.Sdk.Football/QueryParams/FixturesQuery.cs).
2. If new response shape: add a minimal DTO under `Models/` (`get; init;`, nullable as the API allows). Don't invent fields not present in `api-specs/<sport>/`.
3. Register `ApiResponse<YourDto[]>` (or whatever the root is) on the **domain-scoped** `JsonSerializerContext` in `Json/<Domain>JsonContext.cs`. Do NOT add it to a shared/global context — there is no such thing here by design. See [src/ApiSports.Sdk.Football/Json/FixturesJsonContext.cs](src/ApiSports.Sdk.Football/Json/FixturesJsonContext.cs).
4. Add a single method on the domain client that delegates to `http.GetAsync(path, query, <Context>.Default.<TypeInfo>, ct)`. One method per endpoint. See [src/ApiSports.Sdk.Football/Clients/FixturesClient.cs](src/ApiSports.Sdk.Football/Clients/FixturesClient.cs).
5. Extend the sport's contract tests (`FootballEndpointCatalog`, `FootballSampleResponseTests`, `FootballOpenApiContractTests`, equivalents under `Formula1.Tests`) and add the matching sample JSON under `api-specs/<sport>/...` — they are copied into the test output via `<Content Include="..." Link="samples\\..." />` entries in the test `.csproj`. Forgetting either the catalog entry or the `.csproj` content link is the most common cause of test-time `Skip`s.
6. Validate the AOT path: `dotnet publish samples/SampleConsole -c Release` must succeed without trimming warnings about your new types.

### Serialization rules (hard requirements)

- Source-generated `System.Text.Json` only. No reflection, no `JsonSerializerOptions` mutation at runtime, no custom resolvers.
- Every response root type is registered on a small, domain-scoped `JsonSerializerContext`. The `FootballJsonContext` only carries the cross-cutting `Status` type; per-domain contexts (`FixturesJsonContext`, `TeamsJsonContext`, …) carry that domain's roots.
- Custom converters are discouraged. The only one that exists today, `NullableDoubleFromStringConverter`, handles a real API quirk (numbers serialized as strings) and is registered on the specific properties that need it — copy that approach rather than inventing a global converter.
- `ApiResponse<T>.Errors` is intentionally `JsonElement?` because the API returns `[]`, `{}`, or a string in different cases. Don't try to model it as a strongly typed shape.

### Error handling

- HTTP failures → `ApiSportsApiException` with status code, endpoint, and parsed `errors` payload when present.
- `200 OK` with non-empty `Errors` is also turned into `ApiSportsApiException` (treated as `400`).
- `204 No Content` → empty `ApiResponse<T> { Results = 0 }`.
- Do **not** add automatic retries beyond the existing `RateLimitOptions.RetryOn429Once` flag, do not swallow exceptions, do not return defaults for failures.

### Rate limiting

- Per `(host, sport)` pacing limiter implemented in [src/ApiSports.Sdk.Core/ApiSportsPacingRateLimiter.cs](src/ApiSports.Sdk.Core/ApiSportsPacingRateLimiter.cs).
- Plan resolution: `GET /status` once per client, cached for `RateLimitOptions.StatusCacheDuration`. The status call uses a separate `HttpClient` that bypasses the rate limiter (see `ApiSportsClientFactory`).
- Failure / unknown plan → fallback to `RateLimitOptions.FallbackRequestsPerMinute` (default 10/min).
- Override the limit via `options.RateLimit.ResolutionMode = RateLimitResolutionMode.Custom; options.RateLimit.CustomRequestsPerMinute = N;`.
- The limiter is informed of `429` responses via `Report(...)` and applies an extra cooldown (`retry-after` header or `DefaultRetryDelayOn429`).

## NativeAOT discipline

- `<PublishAot>true</PublishAot>` is set on `samples/SampleConsole` — treat its publish output as the canonical AOT smoke test.
- The `AOT` constant is defined when `PublishAot=true` (see `Directory.Build.props`); use `#if AOT` only when behavior must differ at compile time, never to paper over reflection use.
- A change that builds under JIT but breaks AOT publish is considered broken, not "needs a workaround."

## Tests

- xUnit + `xunit.skippablefact`. Contract tests deliberately `Skip.If(!found, ...)` when an `api-specs` sample is missing, so adding the sample JSON without the corresponding `<Content Include>` in the test `.csproj` will silently make the test skip instead of fail.
- `tests/ApiSports.Sdk.Core.Tests/PacingRateLimiterTests.cs` exercises the pacing limiter with fake clocks/status — copy that style when adding limiter behavior, no real HTTP.
- Run a single test: `dotnet test --filter "FullyQualifiedName~<TestClassOrMethod>"`.

## Public API discipline

- Don't widen the public surface for convenience (no overloads that hide intent, no exposing `JsonTypeInfo`/`HttpClient`/handlers).
- Optionality is `T?`, mandatory is `required T`. No defaulted "magic" values.
- Sport clients (`FootballClient`, `Formula1Client`) are pure aggregators — adding logic to them is a structural violation; new behavior belongs on the domain client or a new one.
