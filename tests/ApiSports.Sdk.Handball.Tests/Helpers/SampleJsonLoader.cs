namespace ApiSports.Sdk.Handball.Tests.Helpers;

public static class SampleJsonLoader
{
    public static (bool Found, string? Json) TryLoadHandballSample(string relativePath)
    {
        string path = SamplePaths.ResolveHandballPath(relativePath);
        if (!File.Exists(path))
        {
            return (false, null);
        }

        string json = File.ReadAllText(path);
        return (true, json);
    }
}
