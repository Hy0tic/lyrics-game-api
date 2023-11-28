namespace music_game_api.Queries;

public class GetQuestionQueryResult : QueryResult
{
    public GetQuestionQueryResult(string quote, string album, string song)
    {
        Quote = quote;
        Album = album;
        Song = song;
    }

    public string Quote { get; set; }
    public string Album { get; set; }
    public string Song { get; set; }
    public List<string> Choices { get; set; }
}