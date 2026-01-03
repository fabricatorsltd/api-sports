# ApiSports SDK (.NET)
[![license](https://img.shields.io/badge/license-MIT-orange.svg?style=flat-square)](https://github.com/fabricatorsltd/api-sports/blob/master/LICENSE)
[![CodeFactor](https://img.shields.io/codefactor/grade/github/fabricatorsltd/api-sports?logo=codefactor&style=flat-square)](https://www.codefactor.io/repository/github/fabricatorsltd/api-sports) 
[![Nuget](https://img.shields.io/nuget/v/Fabricators.APISports.Football?label=%20&logo=nuget&style=flat-square)](https://www.nuget.org/packages/Fabricators.APISports.Football/)

API Sports is one of the most complete API service for sport data.
This is an unofficial repository and no partnership is currently made with API Sports.
For any doubt or question about the project itself open an issue.

**ApiSports SDK** is an open-source **.NET SDK** designed to consume the **ApiSports** APIs in a clean, explicit, and predictable way.

It is built with a strong focus on:

* multi-sport support
* NativeAOT compatibility
* zero external dependencies
* explicit APIs over convenience shortcuts

This SDK is not a thin REST wrapper.
It is an opinionated client that favors **clarity, compile-time safety, and long-term maintainability** over hidden magic or runtime flexibility.

If you are looking for:

* a strongly typed API
* full control over serialization
* predictable behavior in AOT and constrained environments

this SDK is designed for you.

If you expect:

* automatic reflection fallbacks
* dynamic query building
* implicit behaviors

this SDK is intentionally **not** trying to provide that.

---

## Design goals (non-negotiable)

This SDK is built around a small set of **non-negotiable design goals**.
They define what the SDK *is allowed* and *not allowed* to do.

### AOT-first, not AOT-compatible

NativeAOT is not an afterthought.

The SDK is designed so that:

* all JSON serialization is known at compile time
* missing metadata causes build-time or publish-time failures
* there are no silent fallbacks to reflection

If something breaks under NativeAOT, that is considered a **design error**, not an edge case.

---

### No external dependencies

The SDK depends only on:

* the .NET runtime
* `System.Text.Json`
* `HttpClient`

No helper libraries, no abstraction layers, no convenience packages.

This keeps:

* startup costs predictable
* binary size under control
* behavior transparent to the user

---

### Explicit APIs over hidden magic

Nothing happens implicitly.

* Query parameters are built from **explicit query objects**
* Serialization is driven by **explicit JsonSerializerContext definitions**
* Errors are surfaced, not swallowed

If something is required, it is required in the type system.
If something is optional, it is explicitly nullable.

---

### Modular by design

The SDK avoids “god objects” by construction:

* one client per sport
* one domain client per API area (fixtures, teams, players, …)
* no single class with dozens of unrelated methods

This allows the SDK to grow without collapsing under its own weight.

---

### Predictability over convenience

Some choices intentionally trade short-term convenience for long-term clarity:

* no dynamic query building
* no runtime schema discovery
* no automatic retries or throttling

The goal is not to surprise the user,
but to make the SDK **boringly predictable** in production.

---

## Supported sports

The SDK is designed to support **multiple sports**, each exposed through a dedicated client.

Currently supported:

* **Football** (ApiSports Football v3)

The public API already reflects a multi-sport design:

```csharp
var sdk = ApiSportsSdk.Create("API_KEY");
ApiSportsHttpClient httpClient = sdk.ForSport(ApiSportsSport.Football);
var football = new FootballClient(httpClient);
```

Each sport lives in its own module, with isolated models, domain clients, and serialization contexts.

---

## High-level architecture

At a high level, the SDK follows a **thin, explicit hierarchy**:

```
ApiSportsSdk
 └─ SportClient (e.g. FootballClient)
     └─ Domain clients (Fixtures, Teams, Players, ...)
```

### ApiSportsSdk

`ApiSportsSdk` is the entry point.

Its responsibilities are limited to:

* holding shared configuration
* creating sport-specific clients

It does not know anything about endpoints or domains.

---

### Sport clients

A sport client (e.g. `FootballClient`) is a **pure aggregator**.

It:

* exposes domain clients as properties
* wires them to shared HTTP infrastructure
* contains no business logic

If logic appears here, the architecture is being violated.

---

### Domain clients

Domain clients map to **conceptual areas of the API**, not technical concerns.

Each domain client:

* groups related endpoints
* exposes one method per endpoint
* accepts strongly typed query objects
* owns its JSON serialization metadata

This keeps the public API understandable and scalable.

---

### Query objects

Endpoints do not accept loose dictionaries or dynamic parameter bags.

Each endpoint defines a **query object** that:

* models supported parameters explicitly
* uses nullability to express optionality
* maps directly and visibly to the query string

There is no runtime inference or hidden behavior.

---

### Serialization boundary

Serialization is handled at the **domain boundary**.

Each domain client:

* owns its own `JsonSerializerContext`
* explicitly registers the response root types it supports

There is no shared global context and no reflection-based discovery.

---

## Using the SDK (happy path)

### Creating the SDK

```csharp
ApiSportsSdk sdk = ApiSportsSdk.Create("API_KEY");
```

The API key is required and explicit.

---

### Selecting a sport

```csharp
ApiSportsHttpClient httpClient = sdk.ForSport(ApiSportsSport.Football);
var football = new FootballClient(httpClient);
```

This does not perform network operations.
It only wires the sport-specific clients.

---

### Calling an endpoint

```csharp
var response = await football.Fixtures.GetAsync(
    new FixturesQuery
    {
        League = 135,
        Season = 2025,
        Team = 490
    },
    cancellationToken);
```

This shows:

* explicit domain access
* strongly typed parameters
* no overload guessing
* no dynamic behavior

---

### Working with the response

All endpoints return the same envelope:

```csharp
ApiResponse<T>
```

```csharp
int results = response.Results;
ApiPaging? paging = response.Paging;
ApiFixtureResponse[]? fixtures = response.Response;
```

Errors are not embedded in the response object.
If the API reports errors, an exception is thrown.

---

## Query objects

Query objects are a core design element.

They exist to make API usage:

* explicit
* type-safe
* self-documenting

Each query object:

* implements `IQueryString`
* explicitly maps properties to query keys
* controls formatting for dates and booleans

Optionality is expressed via nullability.
Required parameters are marked as `required`.

Query objects intentionally do **not**:

* perform cross-field validation
* hide API constraints
* infer behavior at runtime

---

## JSON & NativeAOT

The SDK is designed **for NativeAOT**, not around it.

* All serialization uses System.Text.Json source generation
* No reflection-based serialization exists
* No automatic fallback is provided

Each response root type must be explicitly registered in a serializer context.

If metadata is missing:

* the application fails at build or publish time under NativeAOT
* there is no silent runtime recovery

This behavior is intentional and preferred.

The same serialization model is used under both JIT and NativeAOT.
There is no mode-specific behavior.

---

## Error handling

The SDK surfaces errors **clearly and early**.

### HTTP errors

Non-success HTTP responses result in an `ApiSportsApiException`, including:

* status code
* endpoint URL
* API error payload (when available)

No retries or backoff logic are applied.

---

### API-level errors

If the API returns errors inside a successful HTTP response:

* the response is parsed
* errors are detected
* an exception is thrown

Error states are not left embedded in response objects.

---

### Cancellation

All operations:

* are asynchronous
* accept a `CancellationToken`
* respect cancellation during HTTP and deserialization

---

### What the SDK does not do

The SDK intentionally does **not**:

* retry requests
* throttle calls
* hide transient failures
* convert errors into default values

Behavior is explicit and predictable.

---

## Roadmap

The project evolves in **small, controlled steps**.

Current focus:

* completing Football API coverage
* keeping the public API stable
* validating the architecture in real-world usage

Planned next steps:

* add a second sport module
* improve documentation and examples
* evaluate optional performance benchmarks

The roadmap is **directional, not contractual**.

- [ ] ~~API Football V2~~ *(Not planned)*
- [x] ⚽ API Football V3 *(Work In Progress)*
- [ ] 🏎 API Formula 1
- [ ] 🏀 API Basketball
- [ ] ⚾ API Baseball
- [ ] 🏒 API Hockey
- [ ] 🏉 API Rugby

---

## Contributing

Contribution guidelines are documented separately in `CONTRIBUTING.md`.

The README focuses on **how the SDK works**, not on contribution mechanics.

---

## Links
Our [official website](https://fabricators.ltd/?ref=github)\
API Sports [website](https://api-sports.io/?ref=fabricatorsltd)\
API Football [website](https://api-football.com/?ref=fabricatorsltd)

## Trademark
API Sports and any of the API Sports sub-names are owned by API Sports
