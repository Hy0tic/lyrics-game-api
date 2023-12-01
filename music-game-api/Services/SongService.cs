using music_game_api.Models;
using songDB;
using System.Text.Json;
using System.Text.RegularExpressions;


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
        var result = _excelSongRepository.GetRandomSong();
        //result.Lyrics = GetRandomSentence(result.Lyrics);
        
        return result;
    }

    public async Task<string> GetRandomSongTitle()
    {
        return _excelSongRepository.GetRandomSongTitle();
    }
    
    
    private string RemoveBracketsAndContents(string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            return input;
        }
        // Regular expression to match text in square brackets including the brackets
        var pattern = @"\[.*?\]";
        var result = Regex.Replace(input, pattern, string.Empty);

        return result;
    }
    
    public string GetRandomSentence(string text)
    {
        if (string.IsNullOrEmpty(text))
        {
            return "";
        }

        // Split the text into sentences
        var sentences = text.Split(new[] { '.' }, StringSplitOptions.RemoveEmptyEntries);

        // Check if there are any sentences
        if (sentences.Length == 0)
        {
            return "";
        }

        var random = new Random();
        var index = random.Next(sentences.Length);

        // Trim to remove any leading or trailing white spaces
        return sentences[index].Trim() + ".";
    }

}