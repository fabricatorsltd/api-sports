namespace ApiSports.Sdk.Basketball.Tests.Helpers;

public static class SamplePaths
{
    public static string BasketballRoot { get; } = Path.Combine(AppContext.BaseDirectory, "samples");

    public static string ResolveBasketballPath(string relativePath)
    {
        string normalized = relativePath.Replace('/', Path.DirectorySeparatorChar);
        return Path.Combine(BasketballRoot, normalized);
    }
}
