using TribalWarsPlayerInfo.Models;

namespace TribalWarsPlayerInfo.Services;

public interface IPlayerInfoExtractorService
{
    Task<Player> ExtractPlayerInfoAsync(string playerName, int worldNumber);
}