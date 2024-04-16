
//  db task generate hard for eah player 


using Microsoft.EntityFrameworkCore;
using Shared.Classes;
using Shared.Dto;
using Shared.Services;

#region Init 

var RestService = new RestService();

#endregion

var testDb = new DbService();


Player CurrentPlayer = new Player();
GameService gameService = new GameService();
Lobby GlobalLobby = new Lobby();    
var GlobalIsOwner = false;

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
    GlobalIsOwner = true;

    Console.Write("Hvad skal dit lobbyId? --> ");
    var lobbyIdInput = Console.ReadLine();

    var lobby = new Lobby { HostId = lobbyIdInput, Players = new List<Player>(), };
    lobby.Players.Add(newPlayerHost);

    await RestService.HostLobbyAsync(lobby).ConfigureAwait(false);

    // clear redo this if a new player joins to keep the ui updating in real time 
    GlobalLobby = lobby;
    CurrentPlayer = newPlayerHost;

    await WaitInLobby(lobby.HostId,true);

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
    CurrentPlayer = joinPlayer;

    await WaitInLobby(joinLobbyRequest.JoinId,false);
}




async Task<int> ReadInputAsync()
{
    while (!Console.KeyAvailable)
    {
        await Task.Delay(100); // Check for key press every 100 ms
    }
    var keyInfo = Console.ReadKey(intercept: true);
    if (int.TryParse(keyInfo.KeyChar.ToString(), out int input))
    {
        return input;
    }
    return -1; // Return -1 or some other value to indicate invalid input
}

async Task WaitInLobby(string lobbyId, bool isOwner)
{
    try
    {
        GlobalLobby = await RestService.GetLobbyAsync(lobbyId).ConfigureAwait(false);
        while (true)
        {
        refreshScreen:;
            Console.Clear();

            Console.WriteLine(GlobalLobby.HostId);
            Console.WriteLine("Waiting for host to start the game");
            foreach (var player in GlobalLobby.Players)
            {
                Console.WriteLine(player.Name);
            }
            Console.WriteLine("1. Leave lobby");
            if (isOwner)
            {
                Console.WriteLine("2. Start game");
            }
            Console.Write("--> ");
        awaitagain:;

            Task<int> inputTask = null;
            if (isOwner)
            {
                inputTask = ReadInputAsync();
            }

            var delayTask = Task.Delay(5000);
            Task completedTask = inputTask == null ? await Task.WhenAny(delayTask) : await Task.WhenAny(delayTask, inputTask);

            if (completedTask == inputTask && inputTask != null)
            {
                int input = await inputTask;
                if (input == 1)
                {
                    // Leave lobby logic here
                    break;
                }
                else if (input == 2)
                {
                    // add task to tject if game has started for players that arent owner 
                    // TEMP quick fix 
                    var lobbytoUpdate = await testDb.Lobbys.FirstOrDefaultAsync(l => l.HostId == GlobalLobby.HostId);
                    lobbytoUpdate.HasStarted = true;
                    await testDb.SaveChangesAsync();

                    await Game(); 
                    break;
                }
            }

            var lobbyHasUpdatedCheck = await RestService.GetLobbyAsync(lobbyId).ConfigureAwait(false);
            foreach (var player in lobbyHasUpdatedCheck.Players)
            {
                if (!GlobalLobby.Players.Any(p=>p.Id == player.Id))
                {
                    GlobalLobby = lobbyHasUpdatedCheck;

                    goto refreshScreen;
                    break;
                }
                if(lobbyHasUpdatedCheck.HasStarted == true)
                {
                    await Game();
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
async Task Game()
{
    Console.Clear();
    CurrentPlayer = gameService.GetAStartingHandAsync(CurrentPlayer);
    foreach(var card in CurrentPlayer.Cards)
    {
        if(card.Color == "Red")
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{card.Color} | {card.Value}");
            Console.ForegroundColor = ConsoleColor.White;
        }

        if (card.Color == "Yellow")
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"{card.Color} | {card.Value}");
            Console.ForegroundColor = ConsoleColor.White;
        }

        if (card.Color == "Blue")
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"{card.Color} | {card.Value}");
            Console.ForegroundColor = ConsoleColor.White;
        }
        if (card.Color == "Green")
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{card.Color} | {card.Value}");
            Console.ForegroundColor = ConsoleColor.White;
        }

    }
    Console.ReadLine();

    // count players
    // create a hand for each player 
    // random pick player to start 
    // giveoptions to play a card 
    // random starting card 

}

