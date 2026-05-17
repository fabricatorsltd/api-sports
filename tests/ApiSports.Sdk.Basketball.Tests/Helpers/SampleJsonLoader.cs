namespace ApiSports.Sdk.Basketball.Tests.Helpers;

public static class SampleJsonLoader
{
    public static (bool Found, string? Json) TryLoadBasketballSample(string relativePath)
    {
        string path = SamplePaths.ResolveBasketballPath(relativePath);
        if (!File.Exists(path))
        {
            return (false, null);
        }

        string json = File.ReadAllText(path);
        return (true, json);
    }
}
