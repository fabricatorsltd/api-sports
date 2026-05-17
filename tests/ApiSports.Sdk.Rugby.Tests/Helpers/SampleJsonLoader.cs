namespace ApiSports.Sdk.Rugby.Tests.Helpers;

public static class SampleJsonLoader
{
    public static (bool Found, string? Json) TryLoadRugbySample(string relativePath)
    {
        string path = SamplePaths.ResolveRugbyPath(relativePath);
        if (!File.Exists(path))
        {
            return (false, null);
        }

        string json = File.ReadAllText(path);
        return (true, json);
    }
}
