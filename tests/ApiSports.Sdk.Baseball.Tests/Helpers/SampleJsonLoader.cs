namespace ApiSports.Sdk.Baseball.Tests.Helpers;

public static class SampleJsonLoader
{
    public static (bool Found, string? Json) TryLoadBaseballSample(string relativePath)
    {
        string path = SamplePaths.ResolveBaseballPath(relativePath);
        if (!File.Exists(path))
        {
            return (false, null);
        }

        string json = File.ReadAllText(path);
        return (true, json);
    }
}
