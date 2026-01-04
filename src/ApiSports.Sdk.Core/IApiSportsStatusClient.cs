using ApiSports.Sdk.Abstractions.Models.Common;

namespace ApiSports.Sdk.Core;

internal interface IApiSportsStatusClient
{
    Task<StatusResponse?> GetStatusAsync(CancellationToken ct);
}
