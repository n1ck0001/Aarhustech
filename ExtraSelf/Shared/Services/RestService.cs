using Microsoft.AspNetCore.Mvc;
using Shared.Classes;
using Shared.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Shared.Services
{
    public class RestService
    {
        HttpClient _httpClient;
        string HostId;
        string _url;
        JsonSerializerOptions _serializerOptions;
        
        public RestService() 
        {
            _url = "PlaceholderId";
            HostId = "PlaceholderId";
            _httpClient = new HttpClient();
            _serializerOptions = new JsonSerializerOptions();
        }
            


        public async Task<Lobby> UpdateLobbyAsync(UpdateLobbyDto updateLobbyDto)
        {
            try
            {
                Uri uri = new Uri($"{_url}/Lobby/UpdateLobbyAsync");
                var json = JsonSerializer.Serialize(updateLobbyDto, _serializerOptions);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await _httpClient.PatchAsync(uri, content);
                if(response.IsSuccessStatusCode)
                {
                    // return lobby
                    //var jsonResponse = await response.Content.ReadAsStringAsync();
                    //var updateLobby = JsonSerializer.Deserialize<Lobby>(jsonResponse);
                    //return updateLobby;
                    return null;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task HostLobbyAsync(Lobby lobby)
        {
            try
            {
                HostId = lobby.HostId;
                _url = $"https://localhost:{HostId}";

                Uri uri = new Uri($"{_url}/Lobby/HostLobbyAsync");
                var json = JsonSerializer.Serialize(lobby, _serializerOptions);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync(uri, content);
                if (response.IsSuccessStatusCode)
                {

                }
                else
                {

                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
     
        }

        public async Task JoinLobbyAsync(JoinLobbyDto joinLobbyDto)
        {

            HostId = joinLobbyDto.JoinId;
            _url = $"https://localhost:{HostId}";


            Uri uri = new Uri($"{_url}/Lobby/JoinLobbyAsync");
            var json = JsonSerializer.Serialize(joinLobbyDto);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PatchAsync(uri, content);
            if(response.IsSuccessStatusCode)
            {

            }
            else
            {

            }
        }

        public async Task<Lobby> GetLobbyAsync(string lobbyId)
        {
            Uri uri = new Uri($"{_url}/Lobby/GetLobbyAsync/{lobbyId}");
            var response = await _httpClient.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                var lobby = await response.Content.ReadFromJsonAsync<Lobby>();
                return lobby;
            }
            else
            {
                // return the status code and message sent back from the api as a host id? 
                return new Lobby { HostId = "Couldent fetch lobby" };
                   
            }
        }
    }
}
