using Microsoft.AspNetCore.SignalR;
using music_game_api.Services;

namespace music_game_api.Hubs;

public class LobbyHub : Hub
{
    private SongService SongService { get; set; }
    public LobbyHub(SongService songService)
    {
        SongService = songService;
    }

    public void JoinLobby()
    {
        
    }

    public void GetQuestion()
    {
        
    }
    public void SendAnswer()
    {
        
    }

}