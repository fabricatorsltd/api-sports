namespace ApiSports.Sdk.Mma.Tests.Helpers;

public static class SamplePaths
{
    public static string MmaRoot { get; } = Path.Combine(AppContext.BaseDirectory, "samples");

    public static string ResolveMmaPath(string relativePath)
    {
        string normalized = relativePath.Replace('/', Path.DirectorySeparatorChar);
        return Path.Combine(MmaRoot, normalized);
    }
}
