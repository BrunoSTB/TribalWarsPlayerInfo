using Microsoft.AspNetCore.Mvc;
using TribalWarsPlayerInfo.Services;

namespace TribalWarsPlayerInfo.Controllers;

[ApiController]
[Route("[controller]")]
public class PlayerInformationExtractorController : ControllerBase
{
    private readonly IPlayerInfoExtractorService _extractor;

    public PlayerInformationExtractorController(IPlayerInfoExtractorService extractor)
    {
        _extractor = extractor;
    }

    [HttpGet("/{playerName}/{playerWorld:int}")]
    public async Task<IActionResult> GetPlayerClassificationInfo(string playerName, int playerWorld)
    {
        var result = await _extractor.ExtractPlayerInfoAsync(playerName, playerWorld);
        return Ok(result);
    }
}