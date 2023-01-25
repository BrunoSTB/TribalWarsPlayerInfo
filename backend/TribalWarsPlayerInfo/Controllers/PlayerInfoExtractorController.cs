using Microsoft.AspNetCore.Mvc;
using TribalWarsPlayerInfo.Services;

namespace TribalWarsPlayerInfo.Controllers;

[Route("[controller]")]
[ApiController]
public class PlayerInformationExtractorController : ControllerBase
{
    private readonly IPlayerInfoExtractorService _extractor;

    public PlayerInformationExtractorController(IPlayerInfoExtractorService extractor)
    {
        _extractor = extractor;
    }

    [HttpGet]
    public IActionResult HealthCheck()
    {
      return Ok("Health Check Ok");
    }

    [HttpGet("{playerName}/{playerWorld}")]
    public async Task<IActionResult> GetPlayerClassificationInfo(string playerName, int playerWorld)
    {
        var result = await _extractor.ExtractPlayerInfoAsync(playerName, playerWorld);
        return Ok(result);
    }
}