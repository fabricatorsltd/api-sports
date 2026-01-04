# AGENTS.md

This repository allows and expects contributions generated with the help of automated agents (AI tools).

However, **automation is not allowed to invent, reinterpret, or redesign** the architecture.

This document defines **hard constraints** for any code generated or modified by automated agents.

---

## Scope

This file applies to:

* AI-assisted code generation
* automated refactors
* agent-driven feature additions
* bulk or mechanical code changes

It is **not** a general contribution guide.
See `CONTRIBUTING.md` for human-oriented guidelines.

---

## Non-negotiable rules

Automated agents **must** follow these rules.

Violations will result in rejection, regardless of code quality.

---

### 1. Replicate, do not redesign

This repository has a deliberately constrained architecture.

Agents must:

* replicate existing patterns
* follow established structure
* extend by imitation

Agents must **not**:

* introduce new architectural layers
* refactor existing patterns “for cleanliness”
* consolidate clients, contexts, or domains

If the correct pattern is unclear, stop.

---

### 2. NativeAOT is mandatory

All generated code must be compatible with **NativeAOT**.

Forbidden:

* reflection-based behavior
* runtime type discovery
* implicit serialization metadata
* fallback paths that behave differently under JIT vs AOT

If code works under JIT but not under NativeAOT, it is invalid.

---

### 3. JSON serialization rules

Serialization uses **System.Text.Json source generation only**.

Agents must:

* register every response root type explicitly in a domain-scoped `JsonSerializerContext`
* keep contexts small and domain-specific

Agents must **not**:

* introduce reflection-based serialization
* create shared or global serializer contexts
* guess or infer JSON schemas not defined by the API

If the API specification does not define a response schema, use **minimal placeholder DTOs**.

Do not invent fields.

---

### 4. Query handling is explicit

All endpoints must use **strongly typed query objects**.

Agents must:

* create query objects implementing `IQueryString`
* map parameters explicitly and visibly
* respect formatting rules (dates, booleans, numbers)

Agents must **not**:

* use dynamic dictionaries directly
* infer query parameters automatically
* introduce validation or “smart” behavior

The SDK models the API. It does not fix it.

---

### 5. Client structure is fixed

The client hierarchy is:

```
ApiSportsSdk
 └─ Sport client (e.g. FootballClient)
     └─ Domain clients (Fixtures, Teams, Players, ...)
```

Rules:

* Sport clients are pure aggregators
* Domain clients group related endpoints
* One method per endpoint
* No “god clients”

If adding an endpoint makes a client uncomfortably large, the structure must be reconsidered — not bypassed.

---

### 6. Public API discipline

Agents must:

* keep public APIs explicit
* use nullability to express optionality
* use `required` for mandatory parameters

Agents must **not**:

* expose serializer internals
* expose `JsonTypeInfo`
* add convenience overloads that hide intent

---

### 7. Error handling must remain explicit

Agents must not introduce:

* automatic retries
* throttling
* silent error handling
* default-value fallbacks

Errors must surface clearly and immediately.

---

## When in doubt

If an automated agent cannot confidently apply an existing pattern **without interpretation**, it must stop.

Uncertainty should result in:

* no code generation
* or a request for human review

Guessing is worse than doing nothing.

---

## Final note

This repository favors **predictability over cleverness**.

Automation is welcome,
but only when it behaves as a disciplined contributor — not as a designer.
