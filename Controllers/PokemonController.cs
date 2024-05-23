using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PokemonApp.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace PokemonApp.Controllers
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
            ViewBag.Offset = offset;
            ViewBag.Limit = limit;
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
