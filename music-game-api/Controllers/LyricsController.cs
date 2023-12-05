using Microsoft.AspNetCore.Mvc;
using music_game_api.Models;
using music_game_api.Queries;
using music_game_api.Services;

namespace music_game_api.Controllers;

public class LyricsController : Controller
{
    private SongService SongService { get; set; }

    public LyricsController(SongService songService)
    {
        SongService = songService;
    }
    
    [HttpGet("/getRandomSong")]
    public async Task<IActionResult> GetRandomSong()
    {
        var x = await SongService.GetRandomSong();
        return Ok(x);
    }
    
    [HttpGet("/GetRandomLyrics")]
    public async Task<IActionResult> GetRandomLyrics()
    {
        var randomLyrics = await SongService.GetRandomSongLyrics();
        var result = new GetRandomSongLyricsResult(randomLyrics.quote, randomLyrics.song, randomLyrics.album);
        return Ok(result);
    }

    [HttpGet("getQuestion")]
    public async Task<IActionResult> GetQuestion()
    {
        var randomSong = await SongService.GetRandomSong();
        var randomTitles = new List<string>
        {
            await SongService.GetRandomSongTitle(),
            await SongService.GetRandomSongTitle(),
            await SongService.GetRandomSongTitle(),
            randomSong.Name
        };

        var result = new GetQuestionQueryResult(randomSong.Lyrics,
            randomSong.Album,
            randomSong.Name,
            randomTitles.OrderBy(x=> Random.Shared.Next()).ToList());

        return Ok(result);
    }
    

    
    
}