using System.IO;

namespace ApiSports.Sdk.Football.Tests.Helpers;

public static class SampleJsonLoader
{
    public static (bool Found, string? Json) TryLoadFootballSample(string relativePath)
    {
        string path = SamplePaths.ResolveFootballPath(relativePath);
        if (!File.Exists(path))
        {
            return (false, null);
        }

        string json = File.ReadAllText(path);
        return (true, json);
    }
}
