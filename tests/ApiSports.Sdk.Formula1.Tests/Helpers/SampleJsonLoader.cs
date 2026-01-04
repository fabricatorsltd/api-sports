namespace ApiSports.Sdk.Formula1.Tests.Helpers;

public static class SampleJsonLoader
{
    public static (bool Found, string? Json) TryLoadFormula1Sample(string relativePath)
    {
        string path = SamplePaths.ResolveFormula1Path(relativePath);
        if (!File.Exists(path))
        {
            return (false, null);
        }

        string json = File.ReadAllText(path);
        return (true, json);
    }
}
