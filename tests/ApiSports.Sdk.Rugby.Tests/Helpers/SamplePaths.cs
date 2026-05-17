namespace ApiSports.Sdk.Rugby.Tests.Helpers;

public static class SamplePaths
{
    public static string RugbyRoot { get; } = Path.Combine(AppContext.BaseDirectory, "samples");

    public static string ResolveRugbyPath(string relativePath)
    {
        string normalized = relativePath.Replace('/', Path.DirectorySeparatorChar);
        return Path.Combine(RugbyRoot, normalized);
    }
}
