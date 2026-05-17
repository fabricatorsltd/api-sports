namespace ApiSports.Sdk.Baseball.Tests.Helpers;

public static class SamplePaths
{
    public static string BaseballRoot { get; } = Path.Combine(AppContext.BaseDirectory, "samples");

    public static string ResolveBaseballPath(string relativePath)
    {
        string normalized = relativePath.Replace('/', Path.DirectorySeparatorChar);
        return Path.Combine(BaseballRoot, normalized);
    }
}
