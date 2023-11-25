using Microsoft.AspNetCore.Mvc;
using music_game_api.Models;
using music_game_api.Services;
using System.Text.Json;

namespace music_game_api.Controllers;

public class LyricsController : Controller
{
    private SongService SongService { get; set; }

    public LyricsController(SongService songService)
    {
        SongService = songService;
    }

    [HttpGet("/Hello")]
    public IActionResult Hello()
    {
        return Ok("hello this is Lyrics-game-api");
    }

    [HttpGet("/GetRandomLyrics")]
    public async Task<IActionResult> GetRandomLyrics()
    {
        var randomLyrics = await SongService.GetRandomSongLyrics();
        var result = new GetRandomSongLyricsResult(randomLyrics.quote, randomLyrics.song, randomLyrics.album);
        return Ok(result);
    }

    [HttpGet("/getVersion")]
    public IActionResult Version()
    {
        const string filePath = "buildinfo.json";
        if (!System.IO.File.Exists(filePath))
        {
            return NotFound();
        }
        
        string jsonString = System.IO.File.ReadAllText(filePath);
        var jsonData = JsonSerializer.Deserialize<Dictionary<string, BuildInfo>>(jsonString);

        var buildInfo = jsonData["buildInfo"];

        return Ok(buildInfo);
    }
    
}