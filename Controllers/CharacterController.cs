using Microsoft.AspNetCore.Mvc;
using RickAndMortyAPI.Models;
using RickAndMortyAPI.Services;
using System.Net;
using System.Net.Http;
using System.Net.WebSockets;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace RickAndMortyAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CharacterController : Controller
    {
        private readonly ICharacterService _characterService;

        public CharacterController(ICharacterService characterService)
        {
            _characterService = characterService;
        }

        [HttpGet]
        public async Task<ActionResult<Rootobject>> GetCharacters()
        {
            return await _characterService.GetCharacters();
        }

        [HttpGet("{name}")]
        public async Task<ActionResult<Result>> GetPersonByName(string name)
        {
            var character = await _characterService.GetCharacterByName(name);
            if (character is null)
            {
                return NotFound();
            }
            return Ok(character.Value);
        }
    }
}
