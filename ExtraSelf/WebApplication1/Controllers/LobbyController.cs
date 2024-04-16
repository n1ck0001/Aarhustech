using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shared.Classes;
using Shared.Dto;
using Shared.Services;

namespace WebApplication1.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LobbyController : ControllerBase
    {

        public DbService _dbService = new DbService();
        public LobbyController()
        {
            //_dbService = dbService;
        }

        [HttpPost("HostLobbyAsync")]
        public async Task HostLobbyAsync([FromBody] Lobby lobby)
        {
            try
            {
                var listOfLobbiesToremove = await _dbService.Lobbys.Include(l => l.Players).ToListAsync();
                _dbService.Lobbys.RemoveRange(listOfLobbiesToremove);

                await _dbService.SaveChangesAsync();
                // temp clearing of any lobbies that are in the table 
                await _dbService.Lobbys.AddAsync(lobby);
                await _dbService.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [HttpPatch("JoinLobbyAsync")]
        public async Task<ActionResult> JoinLobbyAsync([FromBody] JoinLobbyDto joinLobbyDto)
        {
            try
            {
                var lobbyToJoin = await _dbService.Lobbys.Include(l => l.Players).FirstOrDefaultAsync(l => l.HostId == joinLobbyDto.JoinId);
                if (lobbyToJoin == null)
                {
                    //cant find a obby with that id 
                    return NotFound();
                }
                else
                {
                    lobbyToJoin.Players.Add(joinLobbyDto.Player);
                    await _dbService.SaveChangesAsync();
                    return Ok();
                }
                return null;



            }
            catch (Exception ex)
            {
                throw ex;
            }

        }



        [HttpPatch("UpdateLobbyAsync")]
        public async Task<Lobby> UpdateLobbyAsync([FromBody]UpdateLobbyDto updateLobbyDto)
        {
            try
            {
                var lobbytoUpdate = await _dbService.Lobbys.Include(l => l.Players).ThenInclude(p => p.Cards).FirstOrDefaultAsync(l => l.HostId == updateLobbyDto.HostId);
                if(lobbytoUpdate.Players.Any(p=>p.Name == updateLobbyDto.Player.Name))
                {
                    var playerToRemove = lobbytoUpdate.Players.FirstOrDefault(p=>p.Name == updateLobbyDto.Player.Name);
                    lobbytoUpdate.Players.Remove(playerToRemove);
                    await _dbService.SaveChangesAsync();
                }
                lobbytoUpdate.Players.Add(updateLobbyDto.Player);
                await _dbService.SaveChangesAsync();
                return lobbytoUpdate;
            }
            catch(Exception ex) 
            {
                return null;
            }
           
        }




        [HttpGet("GetLobbyAsync/{lobbyId}")]
        public async Task<ActionResult<Lobby>> GetLobbyAsync([FromRoute]string lobbyId)
        {
            try
            {
                var lobbyToFetch = await _dbService.Lobbys.Include(l=>l.Players).ThenInclude(p=>p.Cards).FirstOrDefaultAsync(l=>l.HostId == lobbyId);
                if(lobbyToFetch == null)
                {
                    // not found 
                    return NotFound();
                }
                else
                {
                    return lobbyToFetch;
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
