namespace ApiSports.Sdk.Nfl.Tests.Helpers;

public static class SampleJsonLoader
{
    public static (bool Found, string? Json) TryLoadNflSample(string relativePath)
    {
        string path = SamplePaths.ResolveNflPath(relativePath);
        if (!File.Exists(path))
        {
            return (false, null);
        }

        string json = File.ReadAllText(path);
        return (true, json);
    }
}
