namespace ApiSports.Sdk.Formula1.Tests.Helpers;

public static class SamplePaths
{
    public static string Formula1Root { get; } = Path.Combine(AppContext.BaseDirectory, "samples", "formula1");

    public static string OpenApiPath { get; } = Path.Combine(Formula1Root, "openapi.yaml");

    public static string ResolveFormula1Path(string relativePath)
    {
        string normalized = relativePath.Replace('/', Path.DirectorySeparatorChar);
        return Path.Combine(Formula1Root, normalized);
    }
}
