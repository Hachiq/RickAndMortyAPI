using Microsoft.AspNetCore.Mvc;
using RickAndMortyAPI.Models;
using System.Net;
using System.Text.Json;

namespace RickAndMortyAPI.Services
{
    public class CharacterService : ICharacterService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public static string characterUrl = "https://rickandmortyapi.com/api/character";
        public CharacterService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<ActionResult<Rootobject>> GetCharacters()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, characterUrl);
            var client = _httpClientFactory.CreateClient();
            HttpResponseMessage response = await client.SendAsync(request);

            return await response.Content.ReadFromJsonAsync<Rootobject>();
        }

        public async Task<ActionResult<Result>> GetCharacterByName(string name)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, characterUrl);
            var client = _httpClientFactory.CreateClient();
            HttpResponseMessage response = await client.SendAsync(request);

            var characters = await response.Content.ReadFromJsonAsync<Rootobject>();

            foreach (var item in characters.results)
            {
                if (name == item.name)
                {
                    return item;
                }
            }
            return null;
        }
    }
}
