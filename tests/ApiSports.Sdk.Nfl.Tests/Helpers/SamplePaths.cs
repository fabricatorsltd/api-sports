namespace ApiSports.Sdk.Nfl.Tests.Helpers;

public static class SamplePaths
{
    public static string NflRoot { get; } = Path.Combine(AppContext.BaseDirectory, "samples");

    public static string ResolveNflPath(string relativePath)
    {
        string normalized = relativePath.Replace('/', Path.DirectorySeparatorChar);
        return Path.Combine(NflRoot, normalized);
    }
}
