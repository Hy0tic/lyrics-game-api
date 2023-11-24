using Microsoft.AspNetCore.Mvc;

namespace music_game_api.Controllers;

public class LyricsController : Controller
{
    public async Task<IActionResult> GetQuestion()
    {
        return Ok();
    }
    
}