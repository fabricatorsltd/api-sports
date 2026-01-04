using System.Net;
using System.Text;
using System.Text.Json;
using ApiSports.Sdk.Abstractions;
using ApiSports.Sdk.Core;
using ApiSports.Sdk.Football.Clients;
using ApiSports.Sdk.Football.Tests.Helpers;
using Xunit;

namespace ApiSports.Sdk.Football.Tests;

public sealed class LoggingTests
{
    [Fact]
    public async Task NullLoggerDoesNotChangeBehavior()
    {
        using var handler = new FakeHttpMessageHandler((_, _) =>
        {
            HttpResponseMessage response = new(HttpStatusCode.NoContent)
            {
                Content = new ByteArrayContent(Array.Empty<byte>())
            };

            return Task.FromResult(response);
        });

        using var httpClient = new HttpClient(handler)
        {
            BaseAddress = new Uri("https://example.test")
        };

        var apiClient = new ApiSportsHttpClient(httpClient, NullApiSportsLogger.Instance);
        var statusClient = new StatusClient(apiClient);

        ApiResponse<Models.Status> result = await statusClient.GetAsync(CancellationToken.None);

        Assert.NotNull(result);
        Assert.Equal(0, result.Results);
        Assert.Null(result.Response);
        Assert.Null(result.Errors);
    }

    [Fact]
    public async Task LoggerObservesSuccessfulRequest()
    {
        const string json = """
        {
          "get": "status",
          "parameters": [],
          "errors": [],
          "results": 0,
          "paging": {
            "current": 1,
            "total": 1
          },
          "response": {
            "account": {
              "firstname": "Pietro",
              "lastname": "di Caprio",
              "email": "license@fabricators.ltd"
            },
            "subscription": {
              "plan": "Ultra",
              "end": "2026-01-19T21:32:00+00:00",
              "active": true
            },
            "requests": {
              "current": 30,
              "limit_day": 75000
            }
          }
        }
        """;

        var handler = new FakeHttpMessageHandler((_, _) =>
        {
            HttpResponseMessage response = new(HttpStatusCode.OK)
            {
                Content = new StringContent(json, Encoding.UTF8, "application/json")
            };

            return Task.FromResult(response);
        });

        using var httpClient = new HttpClient(handler)
        {
            BaseAddress = new Uri("https://example.test")
        };

        var logger = new TestLogger();
        var apiClient = new ApiSportsHttpClient(httpClient, logger);
        var statusClient = new StatusClient(apiClient);

        ApiResponse<Models.Status> result = await statusClient.GetAsync(CancellationToken.None);

        Assert.NotNull(result.Response);
        Assert.Contains(logger.Entries, entry =>
            entry.Level == ApiSportsLogLevel.Information &&
            entry.Message.Contains("GET /status -> 200", StringComparison.Ordinal));
        Assert.Contains(logger.Entries, entry =>
            entry.Level == ApiSportsLogLevel.Information &&
            entry.Message.Contains("Paging 1 / 1", StringComparison.Ordinal));
    }

    [Fact]
    public async Task LoggerObservesNoContentResponse()
    {
        using var handler = new FakeHttpMessageHandler((_, _) =>
        {
            HttpResponseMessage response = new(HttpStatusCode.NoContent)
            {
                Content = new ByteArrayContent(Array.Empty<byte>())
            };

            return Task.FromResult(response);
        });

        using var httpClient = new HttpClient(handler)
        {
            BaseAddress = new Uri("https://example.test")
        };

        var logger = new TestLogger();
        var apiClient = new ApiSportsHttpClient(httpClient, logger);
        var statusClient = new StatusClient(apiClient);

        ApiResponse<Models.Status> result = await statusClient.GetAsync(CancellationToken.None);

        Assert.NotNull(result);
        Assert.Contains(logger.Entries, entry =>
            entry.Level == ApiSportsLogLevel.Warning &&
            entry.Message.Contains("No content response", StringComparison.Ordinal));
    }

    [Fact]
    public async Task LoggerObservesHttpErrors()
    {
        var handler = new FakeHttpMessageHandler((_, _) =>
        {
            HttpResponseMessage response = new(HttpStatusCode.InternalServerError)
            {
                Content = new ByteArrayContent(Array.Empty<byte>())
            };

            return Task.FromResult(response);
        });

        using var httpClient = new HttpClient(handler)
        {
            BaseAddress = new Uri("https://example.test")
        };

        var logger = new TestLogger();
        var apiClient = new ApiSportsHttpClient(httpClient, logger);
        var statusClient = new StatusClient(apiClient);

        await Assert.ThrowsAsync<ApiSportsApiException>(() => statusClient.GetAsync(CancellationToken.None));

        Assert.Contains(logger.Entries, entry =>
            entry.Level == ApiSportsLogLevel.Error &&
            entry.Message.Contains("HTTP failure", StringComparison.Ordinal));
    }

    [Fact]
    public async Task LoggerObservesJsonDeserializationErrors()
    {
        var handler = new FakeHttpMessageHandler((_, _) =>
        {
            HttpResponseMessage response = new(HttpStatusCode.OK)
            {
                Content = new StringContent("{ invalid json", Encoding.UTF8, "application/json")
            };

            return Task.FromResult(response);
        });

        using var httpClient = new HttpClient(handler)
        {
            BaseAddress = new Uri("https://example.test")
        };

        var logger = new TestLogger();
        var apiClient = new ApiSportsHttpClient(httpClient, logger);
        var statusClient = new StatusClient(apiClient);

        await Assert.ThrowsAsync<JsonException>(() => statusClient.GetAsync(CancellationToken.None));

        Assert.Contains(logger.Entries, entry =>
            entry.Level == ApiSportsLogLevel.Error &&
            entry.Exception is JsonException);
    }

    private sealed record LogEntry(ApiSportsLogLevel Level, string Message, Exception? Exception);

    private sealed class TestLogger : IApiSportsLogger
    {
        public List<LogEntry> Entries { get; } = [];

        public bool IsEnabled(ApiSportsLogLevel level)
        {
            return true;
        }

        public void Log(ApiSportsLogLevel level, string message, Exception? exception = null)
        {
            Entries.Add(new LogEntry(level, message, exception));
        }
    }
}
