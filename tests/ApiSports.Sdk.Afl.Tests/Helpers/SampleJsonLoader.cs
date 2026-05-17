namespace ApiSports.Sdk.Afl.Tests.Helpers;

public static class SampleJsonLoader
{
    public static (bool Found, string? Json) TryLoadAflSample(string relativePath)
    {
        string path = SamplePaths.ResolveAflPath(relativePath);
        if (!File.Exists(path))
        {
            return (false, null);
        }

        string json = File.ReadAllText(path);
        return (true, json);
    }
}
