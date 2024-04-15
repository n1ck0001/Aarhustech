
//  db task generate hard for eah player 


using Shared.Classes;
using Shared.Dto;
using Shared.Services;

#region Init 

var RestService = new RestService();

#endregion


Console.WriteLine("Hejsa!:D");
Console.WriteLine("1. Host et spil");
Console.WriteLine("2. Join et spil");

int joinOrHostGamePlayerChoice  = 0;
int.TryParse(Console.ReadLine(), out joinOrHostGamePlayerChoice);

if(joinOrHostGamePlayerChoice != 1 || joinOrHostGamePlayerChoice != 2)
{
    // invalid inout 
}

if(joinOrHostGamePlayerChoice == 1)
{

    Console.WriteLine("\n");
    Console.Write("Hvad skal din player hedde? --> ");
    var playerName = Console.ReadLine();
    var newPlayerHost = new Player { Name = playerName, Cards = new List<Card>(),};

    Console.Write("Hvad skal dit lobbyId? --> ");
    var lobbyIdInput = Console.ReadLine();

    var lobby = new Lobby { HostId = lobbyIdInput, Players = new List<Player>(), };
    lobby.Players.Add(newPlayerHost);

    await RestService.HostLobbyAsync(lobby).ConfigureAwait(false);

    // clear redo this if a new player joins to keep the ui updating in real time 

    WaitInLobby(lobby.HostId);

    Console.WriteLine("HostId "+lobby.HostId);
    foreach(var player in lobby.Players)
    {
        Console.WriteLine(player.Name);
    }

    while (true)
    {

    }

}
if (joinOrHostGamePlayerChoice == 2)
{
    Console.Write("Hvad skal din player hedde? --> ");
    var joinPlayerName = Console.ReadLine();
    var joinPlayer = new Player { Name = joinPlayerName, Cards = new List<Card>(), };

    Console.Write("Lobby du gerne vil join?(HostId) --> ");
    var hostId = Console.ReadLine();

    var joinLobbyRequest = new JoinLobbyDto { Player = joinPlayer, JoinId = hostId };
    await RestService.JoinLobbyAsync(joinLobbyRequest).ConfigureAwait(false);
    // restserice join lobby 
    WaitInLobby(joinLobbyRequest.JoinId);
}





async Task WaitInLobby(string lobbyId)
{
    try
    {
        var lobbyToPlayIn = await RestService.GetLobbyAsync(lobbyId).ConfigureAwait(false);
        while (true)
        {
        refreshScreen:;
            Console.Clear();

            Console.WriteLine(lobbyToPlayIn.HostId);
            Console.WriteLine("Waiting for host to start the game");
            foreach (var player in lobbyToPlayIn.Players)
            {
                Console.WriteLine(player.Name);
            }
            Console.Write("1. Leave lobby");

        awaitagain:;
            await Task.Delay(5000);
            var lobbyHasUpdatedCheck = await RestService.GetLobbyAsync(lobbyId).ConfigureAwait(false);
            foreach (var player in lobbyHasUpdatedCheck.Players)
            {
                // fails 
                if (!lobbyToPlayIn.Players.Contains(player))
                {
                    lobbyToPlayIn = lobbyHasUpdatedCheck;
                    goto refreshScreen;
                    break;
                }
            }
            goto awaitagain;
        }

    }
    catch (Exception ex)
    {
        throw ex;
    }
   
   // fetch lobby form api and await for host to start 
   // if a new player joins, fetch again to  update. 
}


