using Microsoft.AspNetCore.Mvc;

namespace TribalWarsPlayerInfo.Controllers;

public interface IPlayerInformationExtractor
{
    Task<IActionResult> GetPlayerClassificationInfo(string playerName, int playerWorld);
}