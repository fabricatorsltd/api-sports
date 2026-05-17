namespace ApiSports.Sdk.Afl.Tests.Helpers;

public static class SamplePaths
{
    public static string AflRoot { get; } = Path.Combine(AppContext.BaseDirectory, "samples");

    public static string ResolveAflPath(string relativePath)
    {
        string normalized = relativePath.Replace('/', Path.DirectorySeparatorChar);
        return Path.Combine(AflRoot, normalized);
    }
}
