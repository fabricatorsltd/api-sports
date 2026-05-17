namespace ApiSports.Sdk.Nba.Tests.Helpers;

public static class SamplePaths
{
    public static string NbaRoot { get; } = Path.Combine(AppContext.BaseDirectory, "samples");

    public static string ResolveNbaPath(string relativePath)
    {
        string normalized = relativePath.Replace('/', Path.DirectorySeparatorChar);
        return Path.Combine(NbaRoot, normalized);
    }
}
