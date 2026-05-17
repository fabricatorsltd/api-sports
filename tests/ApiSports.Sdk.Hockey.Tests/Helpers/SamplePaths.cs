namespace ApiSports.Sdk.Hockey.Tests.Helpers;

public static class SamplePaths
{
    public static string HockeyRoot { get; } = Path.Combine(AppContext.BaseDirectory, "samples");

    public static string ResolveHockeyPath(string relativePath)
    {
        string normalized = relativePath.Replace('/', Path.DirectorySeparatorChar);
        return Path.Combine(HockeyRoot, normalized);
    }
}
