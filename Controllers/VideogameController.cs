using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace videogame_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VideogameController : ControllerBase
    {
        private static List<Videogame> games = new List<Videogame>
        {
            new Videogame {
                Id = 1,
                Name = "Halo 3",
                Genre = Genres.Shooter,
                Multiplayer = true,
                AgeRating = AgeRatings.Mature,
                GameRating = GameRatings.OverwhelminglyPositive,
                Exclusive = Exclusives.Xbox
            }
        };
        [HttpGet("GetAll")]
        public ActionResult<List<Videogame>> GetAll()
        {
            return Ok(games);
        }
        [HttpGet("id")]
        public ActionResult<Videogame> Get(int id)
        {
            return Ok(games.FirstOrDefault(g => g.Id == id));
        }

        [HttpPost]
        public ActionResult<Videogame> Create(Videogame game)
        {
            games.Add(game);
            return Ok(games);
        }
        [HttpDelete("id")]
        public ActionResult<Videogame> Delete(int id)
        {
            var selectedGame = games.FirstOrDefault(g => g.Id ==id);
            if (selectedGame == null)
            {
                return NotFound("Game not found.");
            }
            else
            {
                games.Remove(selectedGame);
            }
            return Ok(games);
        }
    }
}