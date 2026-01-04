namespace ApiSports.Sdk.Football.Tests.Helpers;

public static class SamplePaths
{
    public static string FootballRoot { get; } = Path.Combine(AppContext.BaseDirectory, "samples", "football");

    public static string OpenApiPath { get; } = Path.Combine(FootballRoot, "openapi.yaml");

    public static string ResolveFootballPath(string relativePath)
    {
        string normalized = relativePath.Replace('/', Path.DirectorySeparatorChar);
        return Path.Combine(FootballRoot, normalized);
    }
}
