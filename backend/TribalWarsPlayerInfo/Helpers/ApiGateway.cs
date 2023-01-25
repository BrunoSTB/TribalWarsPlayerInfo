namespace TribalWarsPlayerInfo.Helpers;

public class ApiGateway : IApiGateway
{
    public async Task<string> RetrieveData(string url)
    {
        var client = new HttpClient();
        return await client.GetStringAsync(url);
    }
}