namespace TribalWarsPlayerInfo.Tools;

public interface IApiGateway
{
    Task<string> RetrieveData(string url);
}