using ApiSports.Sdk.Football.QueryParams;
using ApiSports.Sdk.Football.Tests.Helpers;
using Xunit;
using YamlDotNet.RepresentationModel;

namespace ApiSports.Sdk.Football.Tests;

public sealed class FootballProviderCompatibilityTests
{
    [Fact]
    public void BundledProviderContractIsApiFootball393()
    {
        using StreamReader reader = File.OpenText(SamplePaths.OpenApiPath);
        YamlStream stream = new();
        stream.Load(reader);

        YamlMappingNode root = Assert.IsType<YamlMappingNode>(stream.Documents[0].RootNode);
        YamlMappingNode info = Assert.IsType<YamlMappingNode>(root.Children[new YamlScalarNode("info")]);
        YamlScalarNode version = Assert.IsType<YamlScalarNode>(info.Children[new YamlScalarNode("version")]);

        Assert.Equal("3.9.3", version.Value);
    }

    [Fact]
    public void ApiFootball393QueryAdditionsAreMappedExplicitly()
    {
        Assert.Equal("true", new FixturesRoundsWithDatesQuery
        {
            League = 39,
            Season = 2024
        }.ToQueryParameters()["dates"]);
        Assert.Equal("true", new FixturesStatisticsQuery
        {
            Fixture = 1,
            Half = true
        }.ToQueryParameters()["half"]);
        Assert.Equal("1-2", new InjuriesQuery
        {
            Ids = "1-2"
        }.ToQueryParameters()["ids"]);
        Assert.Equal("1-2", new SidelinedQuery
        {
            Players = "1-2"
        }.ToQueryParameters()["players"]);
        Assert.Equal("3-4", new TrophiesQuery
        {
            Coachs = "3-4"
        }.ToQueryParameters()["coachs"]);
    }
}
