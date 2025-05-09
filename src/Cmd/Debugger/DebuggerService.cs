using ZoneChan.ZoneClient.Games;

namespace ZoneChan.Cmd.Debugger;

internal sealed class DebuggerService
{
    private readonly IGameClient gameClient;
    
    public DebuggerService(IGameClient gameClient)
    {
        this.gameClient = gameClient;
    }
    
    public async Task Run()
    {
        var games = gameClient.GetAllGamesAsync();

        await foreach (var game in games)
        {
            Console.WriteLine($"{game.Id} {game.Title}");
        }
    }
}