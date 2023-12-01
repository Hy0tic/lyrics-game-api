using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace music_game_api.Controllers;

public class HealthController : Controller
{
    [HttpGet("/Hello")]
    public async Task<IActionResult> Hello()
    {
        return Ok("hello this is the lyrics game api");
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