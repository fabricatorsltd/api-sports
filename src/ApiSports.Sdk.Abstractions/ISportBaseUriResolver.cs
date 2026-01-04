namespace ApiSports.Sdk.Abstractions;

public interface ISportBaseUriResolver
{
    Uri Resolve(ApiSportsSport sport);
}
