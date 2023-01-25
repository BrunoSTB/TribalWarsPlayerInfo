using AngleSharp.Dom;
using TribalWarsPlayerInfo.Models;
using TribalWarsPlayerInfo.Helpers;

namespace TribalWarsPlayerInfo.Services;

public class PlayerInfoExtractorService : IPlayerInfoExtractorService
{
    private readonly IApiGateway _apiGateway;
    private readonly IHtmlManipulator _htmlManipulator;
    

    public PlayerInfoExtractorService(IApiGateway apiGateway, IHtmlManipulator htmlManipulator)
    {
        _apiGateway = apiGateway;
        _htmlManipulator = htmlManipulator;
    }

    public async Task<Player> ExtractPlayerInfoAsync(string playerName, int worldNumber)
    {
        var response = await _apiGateway.RetrieveData(
            $"https://br{worldNumber}.tribalwars.com.br/guest.php?name={playerName}");
        
        var document = await _htmlManipulator.ProcessHtmlString(response);
        var infos = document.GetElementsByClassName("lit-item");
        
    return CreatePlayer(infos);
    }
    
    private Player CreatePlayer(IHtmlCollection<IElement> rawPlayerData)
    {
        var playerClassification = Convert.ToInt32(rawPlayerData[0].TextContent);
        var playerName = _htmlManipulator.CleanHtmlTextContent(rawPlayerData[1].TextContent);
        var playerTribe = _htmlManipulator.CleanHtmlTextContent(rawPlayerData[2].TextContent);
        var playerTotalPoints = Convert.ToInt32(rawPlayerData[3].TextContent.Replace(".", ""));
        var playerVillageCount = Convert.ToInt32(rawPlayerData[4].TextContent);
        var pointsPerVillage = Convert.ToInt32(rawPlayerData[5].TextContent.Replace(".", ""));

        return new Player
        (
            playerClassification,
            playerName,
            playerTribe,
            playerTotalPoints,
            playerVillageCount,
            pointsPerVillage
        );
    }
}