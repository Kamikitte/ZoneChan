using System.Text.Json;

namespace ZoneChan.ZoneClient.Games;

internal sealed class GameClient : IGameClient
{
    private readonly HttpClient httpClient;
    
    public GameClient(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }

    public async IAsyncEnumerable<Game> GetAllGamesAsync()
    {
        var httpResponse = await httpClient.GetAsync("sam/latest_alpha/latest_data.php?cmd=list&cat=games");
        
        httpResponse.EnsureSuccessStatusCode();
        
        var json = await httpResponse.Content.ReadAsStringAsync();
        
        var response = JsonSerializer.Deserialize<Response>(json);
        
        var page = response?.Message?.Pagination?.Page ?? throw new Exception();
        var total = response.Message?.Pagination?.Total ?? throw new Exception();

        while (page <= total)
        {
            httpResponse = await httpClient.GetAsync($"sam/latest_alpha/latest_data.php?cmd=list&cat=games&page={page}");

            httpResponse.EnsureSuccessStatusCode();
            
            json = await httpResponse.Content.ReadAsStringAsync();
            response = JsonSerializer.Deserialize<Response>(json);

            if (response?.Message?.Games is null)
            {
                throw new Exception();
            }
            
            foreach (var game in response.Message.Games)
            {
                yield return game;
            }

            page++;
        }
    }
}