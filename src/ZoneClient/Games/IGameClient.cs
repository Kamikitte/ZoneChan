namespace ZoneChan.ZoneClient.Games;

public interface IGameClient
{
    IAsyncEnumerable<Game> GetAllGamesAsync();
}