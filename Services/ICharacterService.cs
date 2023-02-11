using Microsoft.AspNetCore.Mvc;
using RickAndMortyAPI.Models;

namespace RickAndMortyAPI.Services
{
    public interface ICharacterService
    {
        Task<ActionResult<Rootobject>> GetCharacters();
        Task<ActionResult<Result>> GetCharacterByName(string name);
    }
}
