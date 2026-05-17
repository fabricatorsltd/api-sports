namespace ApiSports.Sdk.Volleyball.Tests.Helpers;

public static class SamplePaths
{
    public static string VolleyballRoot { get; } = Path.Combine(AppContext.BaseDirectory, "samples");

    public static string ResolveVolleyballPath(string relativePath)
    {
        string normalized = relativePath.Replace('/', Path.DirectorySeparatorChar);
        return Path.Combine(VolleyballRoot, normalized);
    }
}
