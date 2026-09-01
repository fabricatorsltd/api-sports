# Provider compatibility

This repository records the upstream API contract used by each public SDK
module. API-Sports does not use the SDK package version as its API version, so
the provider version and SDK version must be tracked independently.

## Football

| SDK package | Provider product | Provider contract | Last reviewed | Review status |
| --- | --- | --- | --- | --- |
| `ApiSports.Sdk.Football` 1.1.1 | API-Football v3 | 3.9.3 | 2026-09-01 | `Team.Country` corrected to nullable from observed provider data |
| `ApiSports.Sdk.Football` 1.1.0 | API-Football v3 | 3.9.3 | 2026-08-31 | All 3.9.3 changelog entries reviewed |

The provider documentation and the bundled specification both identify the
current contract as API-Football 3.9.3. Future provider reviews must update this
table and the bundled specification together. A new provider field, endpoint or
query capability is an SDK feature; correcting a mismatch against the recorded
provider contract is an SDK fix.

The bundled `api-specs/football/openapi.yaml` snapshot has SHA-256
`35487c373c2f3fb25da93254bb8a5399fac31068f91d3163a9bf91227de03244`.
The upstream changelog is
<https://www.api-football.com/documentation-v3#section/Changelog>.

### API-Football 3.9.3 coverage

| Provider change | SDK support |
| --- | --- |
| `players/profiles` endpoint | `PlayersClient.GetProfilesAsync` |
| `players/teams` endpoint | `PlayersClient.GetTeamsAsync` |
| Fixture `status.extra` | `FixtureStatus.Extra`, added in SDK 1.1.0 |
| Fixture league `standings` | `League.Standings` |
| Dated fixture rounds | `FixturesClient.GetRoundsWithDatesAsync`, added in SDK 1.1.0 |
| Fixture statistics `half` query | `FixturesStatisticsQuery.Half` |
| Injuries multi-fixture `ids` query | `InjuriesQuery.Ids` |
| Team statistics goals over/under | `TeamStatisticsGoalsForAgainst.UnderOver` |
| Sidelined multi-player and multi-coach queries | `SidelinedQuery.Players` and `SidelinedQuery.Coachs` |
| Trophies multi-player and multi-coach queries | `TrophiesQuery.Players` and `TrophiesQuery.Coachs` |

The compatibility test suite asserts the bundled provider version, explicit
query mappings, source-generated response roots and representative official
response examples. NativeAOT publication remains a release gate.
