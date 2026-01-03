# Contributing to ApiSports SDK

Thank you for your interest in contributing to **ApiSports SDK**.

This project values **clarity, predictability, and long-term maintainability** over short-term convenience.
Before contributing, please read this document carefully.

If a change conflicts with the principles described here, it is unlikely to be accepted.

---

## Guiding principles

Contributions must respect the following non-negotiable principles:

* **AOT-first design**
* **No external dependencies**
* **Explicit APIs**
* **No hidden magic**
* **Predictable behavior over convenience**

These principles are more important than feature completeness.

---

## NativeAOT is a hard requirement

This SDK is designed to work **with NativeAOT**, not around it.

As a contributor, you must ensure that your changes:

* do not rely on reflection-based behavior
* do not introduce runtime type discovery
* do not depend on implicit serialization metadata
* do not add fallback paths that behave differently under JIT vs AOT

If a feature only works under JIT, it is considered **broken**.

---

## JSON serialization rules

* Only **System.Text.Json source generation** is allowed
* Every response root type **must** be explicitly registered in a `JsonSerializerContext`
* No shared or global “mega-contexts”
* No reflection-based serialization
* Custom converters are discouraged and must be justified

If a type is missing from the context, the correct behavior is to **fail early**, not to recover silently.

---

## Public API rules

When adding or modifying public APIs:

* Prefer **explicit types** over convenience overloads
* Avoid long parameter lists
* Use **query objects** for endpoint parameters
* Express optionality via nullability
* Use `required` for parameters that are mandatory per API semantics

Do not expose:

* `JsonTypeInfo`
* serializer internals
* HTTP infrastructure details

---

## Query objects

All endpoints must use **strongly typed query objects**:

* One query object per endpoint (or per closely related endpoints)
* Implement `IQueryString`
* Explicitly map properties to query string keys
* Control formatting explicitly (dates, booleans, numbers)

Query objects must **not**:

* perform validation logic
* enforce cross-field constraints
* hide API behavior

They model the API — they do not “fix” it.

---

## Client structure

The client hierarchy is intentional and must be preserved:

* `ApiSportsSdk`
  → sport clients (e.g. `FootballClient`)
  → domain clients (Fixtures, Teams, Players, …)

Rules:

* Sport clients are **pure aggregators**
* Domain clients group related endpoints
* One method per endpoint
* No “god clients” with unrelated methods

If adding a new endpoint makes an existing client grow uncomfortably, the structure should be revisited.

---

## Adding new endpoints

When adding support for a new endpoint:

1. Identify the correct **domain client**
2. Create or extend a **query object**
3. Add a single method mapping to the endpoint
4. Register the response root type in the domain’s `JsonSerializerContext`
5. Ensure NativeAOT publish succeeds

Avoid adding multiple endpoints in a single method.

---

## Response DTOs

If response DTOs already exist, reuse them.

If they do not exist:

* Create **minimal, honest DTOs**
* Use `public get; init;`
* Use explicit nullability
* Do **not** invent schemas not present in the API documentation

Placeholders are acceptable when the API spec does not define response bodies.

---

## Error handling

Do not introduce:

* silent error swallowing
* automatic retries
* implicit fallback behavior

Errors should:

* surface early
* include context
* be handled by the caller

Retry and throttling strategies belong to application code, not the SDK.

---

## Code style

* Follow existing naming and file layout
* Use explicit types where the type is not obvious
* Keep classes small and focused
* Avoid clever abstractions

If code requires explanation to justify its existence, it is probably too complex.

---

## Tests and samples

If applicable:

* update or add sample usage
* ensure sample projects still publish under NativeAOT
* avoid tests that depend on runtime reflection

---

## Submitting a pull request

Before submitting a PR:

* Ensure the project builds
* Ensure NativeAOT publish succeeds
* Re-read this document

A PR may be rejected if it:

* introduces hidden magic
* weakens AOT guarantees
* increases surface complexity without strong justification

This is not personal — it is architectural consistency.

---

## Final note

This project values **discipline over speed**.

Small, well-reasoned contributions are preferred over large feature dumps.
When in doubt, open an issue to discuss design before writing code.

Thank you for helping keep the SDK clean, explicit, and boring in the best possible way.
