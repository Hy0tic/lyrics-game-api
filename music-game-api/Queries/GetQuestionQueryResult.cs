namespace music_game_api.Queries;

public class GetQuestionQueryResult : QueryResult
{
    public GetQuestionQueryResult(string quote, string album, string song, List<string> choices)
    {
        Quote = quote;
        Album = album;
        Song = song;
        Choices = choices;
    }

    public string Quote { get; set; }
    public string Album { get; set; }
    public string Song { get; set; }
    public List<string> Choices { get; set; }
}