using ApiSports.Sdk.Abstractions;
using ApiSports.Sdk.Core;
using ApiSports.Sdk.Formula1.Json;
using ApiSports.Sdk.Formula1.Models;
using ApiSports.Sdk.Formula1.QueryParams;

namespace ApiSports.Sdk.Formula1.Clients;

public sealed class CompetitionsClient(ApiSportsHttpClient http)
{
    public Task<ApiResponse<ApiCompetitionResponse[]>> GetAsync(
        CompetitionsQuery query,
        CancellationToken cancellationToken = default)
    {
        return http.GetAsync(
            "/competitions",
            query,
            Formula1JsonSerializerContext.Default.ApiResponseApiCompetitionResponseArray,
            cancellationToken);
    }
}
