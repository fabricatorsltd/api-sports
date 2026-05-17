namespace ApiSports.Sdk.Mma.Tests.Helpers;

public static class SampleJsonLoader
{
    public static (bool Found, string? Json) TryLoadMmaSample(string relativePath)
    {
        string path = SamplePaths.ResolveMmaPath(relativePath);
        if (!File.Exists(path))
        {
            return (false, null);
        }

        string json = File.ReadAllText(path);
        return (true, json);
    }
}
