using ApiSports.Sdk.Abstractions;

namespace ApiSports.Sdk.Core;

public sealed class RateLimitTrackingHandler(IRateLimitStateStore store, RateLimitScope scope) : DelegatingHandler
{
    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        HttpResponseMessage response = await base.SendAsync(request, cancellationToken).ConfigureAwait(false);

        DateTimeOffset nowUtc = DateTimeOffset.UtcNow;
        RateLimitSnapshot? snapshot = RateLimitHeaderParser.TryParse(response.Headers, nowUtc);
        if (snapshot is not null)
        {
            await store.SetAsync(scope, snapshot, cancellationToken).ConfigureAwait(false);
        }

        return response;
    }
}
