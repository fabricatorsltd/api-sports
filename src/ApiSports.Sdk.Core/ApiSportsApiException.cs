using System.Net;
using System.Text.Json;

namespace ApiSports.Sdk.Core;

public sealed class ApiSportsApiException(
    string message,
    HttpStatusCode statusCode,
    string? endpoint,
    JsonElement? errors,
    Exception? inner = null)
    : Exception(message, inner)
{
    public HttpStatusCode StatusCode { get; } = statusCode;
    public string? Endpoint { get; } = endpoint;
    public JsonElement? Errors { get; } = errors;
}
