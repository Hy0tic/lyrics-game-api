using music_game_api.Models;
using System.Text.Json;

namespace music_game_api.Services;


public class SongService
{
    private const string LyricsApiUrl = "https://taylorswiftapi.onrender.com/get";
    private readonly HttpClient _httpClient;

    public SongService()
    {
        _httpClient = new HttpClient();
    }

    public async Task<GetRandomSongLyricsResult> GetRandomSongLyrics()
    {
        var response = await _httpClient.GetAsync(LyricsApiUrl);
        response.EnsureSuccessStatusCode();
        var responseBody = await response.Content.ReadAsStringAsync();
        var result = JsonSerializer.Deserialize<GetRandomSongLyricsResult>(responseBody);
        
        return result;
    }

    public async Task GetRandomSongLyrics()
    {

    }
}