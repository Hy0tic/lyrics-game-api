namespace music_game_api.Models;

public class GetRandomSongLyricsResult
{
    public string quote { get; set; }
    public string song { get; set; }
    public string album { get; set; }

    public GetRandomSongLyricsResult(string quote, string song, string album)
    {
        this.quote = quote;
        this.song = song;
        this.album = album;
    }

    public GetRandomSongLyricsResult()
    {
        
    }
}