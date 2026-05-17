namespace ApiSports.Sdk.Handball.Tests.Helpers;

public static class SamplePaths
{
    public static string HandballRoot { get; } = Path.Combine(AppContext.BaseDirectory, "samples");

    public static string ResolveHandballPath(string relativePath)
    {
        string normalized = relativePath.Replace('/', Path.DirectorySeparatorChar);
        return Path.Combine(HandballRoot, normalized);
    }
}
