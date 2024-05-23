using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PREFINAL_ASSIGNMENT_TWO_POKEMON_TAMAYO_ANGELIKA_BSCS_32E1.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace PREFINAL_ASSIGNMENT_TWO_POKEMON_TAMAYO_ANGELIKA_BSCS_32E1.Controllers
{
    public class PokemonController : Controller
    {
        private readonly HttpClient _httpClient;

        public PokemonController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IActionResult> Index(int offset = 0, int limit = 20)
        {
            var response = await _httpClient.GetStringAsync($"https://pokeapi.co/api/v2/pokemon?offset={offset}&limit={limit}");
            var pokemonList = JsonConvert.DeserializeObject<PokemonList>(response);
            return View(pokemonList);
        }

        public async Task<IActionResult> Details(string name)
        {
            var response = await _httpClient.GetStringAsync($"https://pokeapi.co/api/v2/pokemon/{name}");
            var pokemon = JsonConvert.DeserializeObject<Pokemon>(response);
            return View(pokemon);
        }
    }

    public class PokemonList
    {
        public List<Result> Results { get; set; }
    }

    public class Result
    {
        public string Name { get; set; }
        public string Url { get; set; }
    }
}
