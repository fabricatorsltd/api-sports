using System.Text.Json.Serialization;

namespace ApiSports.Sdk.Abstractions.Models.Common;

public sealed class StatusResponse
{
    [JsonPropertyName("account")]
    public StatusAccount? Account { get; init; }

    [JsonPropertyName("subscription")]
    public StatusSubscription? Subscription { get; init; }

    [JsonPropertyName("requests")]
    public StatusRequests? Requests { get; init; }
}

public sealed class StatusAccount
{
    [JsonPropertyName("firstname")]
    public string? FirstName { get; init; }

    [JsonPropertyName("lastname")]
    public string? LastName { get; init; }

    [JsonPropertyName("email")]
    public string? Email { get; init; }
}

public sealed class StatusSubscription
{
    [JsonPropertyName("plan")]
    public string? Plan { get; init; }

    [JsonPropertyName("end")]
    public DateTimeOffset? End { get; init; }

    [JsonPropertyName("active")]
    public bool? Active { get; init; }
}

public sealed class StatusRequests
{
    [JsonPropertyName("current")]
    public int? Current { get; init; }

    [JsonPropertyName("limit_day")]
    public int? LimitDay { get; init; }
}
