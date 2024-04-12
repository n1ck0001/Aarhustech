﻿
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
else if(joinOrHostGamePlayerChoice == 1)
{
    Console.WriteLine("\n");
    Console.Write("Hvad skal din player hedde? --> ");
    var playerName = Console.ReadLine();
    var newPlayerHost = new Player { Name = playerName, };

    Console.Write("Hvad skal dit lobbyId? --> ");
    var lobbyIdInput = Console.ReadLine();

    var lobby = new Lobby { HostId = lobbyIdInput, Players = new List<Player>(), };
    lobby.Players.Add(newPlayerHost);

    await RestService.HostLobbyAsync(lobby);

    // clear redo this if a new player joins to keep the ui updating in real time 
    Console.WriteLine("HostId "+lobby.HostId);
    foreach(var player in lobby.Players)
    {
        Console.WriteLine(player.Name);
    }

    while (true)
    {

    }

}
else if (joinOrHostGamePlayerChoice == 2)
{
    Console.Write("Hvad skal din player hedde? --> ");
    var joinPlayerName = Console.ReadLine();
    var joinPlayer = new Player { Name = joinPlayerName, };

    Console.Write("Lobby du gerne vil join?(HostId) --> ");
    var hostId = Console.ReadLine();

    var joinLobbyRequest = new JoinLobbyDto { Player = joinPlayer, JoinId = hostId };

    // restserice join lobby 

}


