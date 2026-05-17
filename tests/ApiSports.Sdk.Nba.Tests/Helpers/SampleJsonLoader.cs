namespace ApiSports.Sdk.Nba.Tests.Helpers;

public static class SampleJsonLoader
{
    public static (bool Found, string? Json) TryLoadNbaSample(string relativePath)
    {
        string path = SamplePaths.ResolveNbaPath(relativePath);
        if (!File.Exists(path))
        {
            return (false, null);
        }

        string json = File.ReadAllText(path);
        return (true, json);
    }
}
