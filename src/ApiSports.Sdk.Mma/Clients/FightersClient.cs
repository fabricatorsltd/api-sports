using ApiSports.Sdk.Abstractions;
using ApiSports.Sdk.Core;
using ApiSports.Sdk.Mma.Json;
using ApiSports.Sdk.Mma.Models;
using ApiSports.Sdk.Mma.QueryParams;

namespace ApiSports.Sdk.Mma.Clients;

public sealed class FightersClient(ApiSportsHttpClient http)
{
    public Task<ApiResponse<Fighter[]>> GetAsync(
        FightersQuery query,
        CancellationToken cancellationToken = default)
    {
        return http.GetAsync(
            "/fighters",
            query,
            MmaJsonSerializerContext.Default.ApiResponseFighterArray,
            cancellationToken);
    }

    public Task<ApiResponse<FighterRecord[]>> GetRecordsAsync(
        FighterRecordsQuery query,
        CancellationToken cancellationToken = default)
    {
        return http.GetAsync(
            "/fighters/records",
            query,
            MmaJsonSerializerContext.Default.ApiResponseFighterRecordArray,
            cancellationToken);
    }
}
