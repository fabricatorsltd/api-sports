namespace ApiSports.Sdk.Volleyball.Tests.Helpers;

public static class SampleJsonLoader
{
    public static (bool Found, string? Json) TryLoadVolleyballSample(string relativePath)
    {
        string path = SamplePaths.ResolveVolleyballPath(relativePath);
        if (!File.Exists(path))
        {
            return (false, null);
        }

        string json = File.ReadAllText(path);
        return (true, json);
    }
}
