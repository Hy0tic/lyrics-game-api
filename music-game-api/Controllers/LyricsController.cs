using Microsoft.AspNetCore.Mvc;
using music_game_api.Models;
using music_game_api.Services;

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
    
}