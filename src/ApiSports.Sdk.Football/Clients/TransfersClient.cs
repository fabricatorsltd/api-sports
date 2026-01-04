using ApiSports.Sdk.Abstractions;
using ApiSports.Sdk.Core;
using ApiSports.Sdk.Football.Json;
using ApiSports.Sdk.Football.Models;
using ApiSports.Sdk.Football.QueryParams;

namespace ApiSports.Sdk.Football.Clients;

public sealed class TransfersClient(ApiSportsHttpClient http)
{
    public Task<ApiResponse<TransferResponse[]>> GetAsync(
        TransfersQuery query,
        CancellationToken cancellationToken = default)
    {
        return http.GetAsync(
            "/transfers",
            query,
            TransfersJsonContext.Default.ApiResponseTransferResponseArray,
            cancellationToken);
    }
}
