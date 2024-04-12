
//  db task generate hard for eah player 


using Shared.Classes;

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

    Console.Write("Hvad skal din lobby hedde? --> ");
    var lobbyName = Console.ReadLine();

    var lobby = new Lobby { Name = lobbyName, Players = new List<Player>(), };
    lobby.Players.Add(newPlayerHost);

}
else if (joinOrHostGamePlayerChoice == 2)
{

}


