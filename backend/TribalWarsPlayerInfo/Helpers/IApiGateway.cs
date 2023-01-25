namespace TribalWarsPlayerInfo.Helpers;

public interface IApiGateway
{
    Task<string> RetrieveData(string url);
}