using music_game_api.Models;
using songDB;
using System.Text.Json;

namespace music_game_api.Services;


public class SongService
{
    private const string LyricsApiUrl = "https://taylorswiftapi.onrender.com/get";
    private readonly HttpClient _httpClient;
    private readonly ExcelSongRepository _excelSongRepository;

    public SongService( HttpClient httpClient,ExcelSongRepository excelSongRepository)
    {
        _httpClient = httpClient;
        _excelSongRepository = excelSongRepository;
    }

    public async Task<GetRandomSongLyricsResult> GetRandomSongLyrics()
    {
        var response = await _httpClient.GetAsync(LyricsApiUrl);
        response.EnsureSuccessStatusCode();
        var responseBody = await response.Content.ReadAsStringAsync();
        var result = JsonSerializer.Deserialize<GetRandomSongLyricsResult>(responseBody);
        
        return result;
    }

    public async Task<Song> GetRandomSong()
    {
        return _excelSongRepository.GetRandomSong();
    }

    public async Task<string> GetRandomSongTitle()
    {
        return _excelSongRepository.GetRandomSongTitle();
    }

}