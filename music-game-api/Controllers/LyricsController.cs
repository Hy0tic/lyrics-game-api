using Microsoft.AspNetCore.Mvc;
using music_game_api.Services;

namespace music_game_api.Controllers;

public class LyricsController : Controller
{
    private SongService SongService { get; set; }

    public LyricsController(SongService songService)
    {
        SongService = songService;
    }

    [HttpGet("/GetRandomLyrics")]
    public async Task<IActionResult> GetRandomLyrics()
    {
        var randomLyrics = await SongService.GetRandomSongLyrics();
        return Ok(randomLyrics);
    }
    
}