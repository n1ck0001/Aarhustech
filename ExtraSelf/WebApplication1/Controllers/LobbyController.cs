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
                //foreach(var item in await _dbService.Lobbys.ToListAsync()) { _dbService.Lobbys.Remove(item); }
                var listOfLobbiesToremove = await _dbService.Lobbys.Include(l => l.Players).ToListAsync();
                _dbService.Lobbys.RemoveRange(listOfLobbiesToremove);


                //var listofPlayersToRemove = await _dbService.Players.ToListAsync();
                //_dbService.Players.RemoveRange(listofPlayersToRemove);

                //foreach(var item in listOfLobbiesToremove)
                //{
                //    _dbService.Lobbys.Remove(item);
                //}

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
