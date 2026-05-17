using ApiSports.Sdk.Abstractions;
using ApiSports.Sdk.Core;
using ApiSports.Sdk.Mma.Json;
using ApiSports.Sdk.Mma.QueryParams;

namespace ApiSports.Sdk.Mma.Clients;

public sealed class CategoriesClient(ApiSportsHttpClient http)
{
    public Task<ApiResponse<string[]>> GetAsync(
        CategoriesQuery? query = null,
        CancellationToken cancellationToken = default)
    {
        return http.GetAsync(
            "/categories",
            query,
            MmaJsonSerializerContext.Default.ApiResponseStringArray,
            cancellationToken);
    }
}
