namespace ApiSports.Sdk.Hockey.Tests.Helpers;

public static class SampleJsonLoader
{
    public static (bool Found, string? Json) TryLoadHockeySample(string relativePath)
    {
        string path = SamplePaths.ResolveHockeyPath(relativePath);
        if (!File.Exists(path))
        {
            return (false, null);
        }

        string json = File.ReadAllText(path);
        return (true, json);
    }
}
