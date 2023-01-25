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
        /* Controller class that lists creates all routes listed below. */

        /* References the VideogameService class to allow for the manipulation of data for each route. */
        private readonly IVideogameService _videogameService;

        /* Creates the variable used to reference the VideogameService class. */
        public VideogameController(IVideogameService videogameService)
        {
            _videogameService = videogameService;
        }

        /* Route that retrieves everything from the database and lists it out. */
        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<GetVideogameDto>>>> GetAll()
        {
            return Ok(await _videogameService.GetAllVideogames());
        }

        /* Route that retrieves a specific entry in the database by using its ID number. */
        [HttpGet("IDSearch/{id:guid}")]
        public async Task<ActionResult<ServiceResponse<GetVideogameDto>>> Get(int id)
        {
            return Ok(await _videogameService.GetVideogame(id));
        }

        /* Route that retrieves all entries in the database that are under the same genre. */
        [HttpGet("GenreSearch/{genre}")]
        public async Task<ActionResult<ServiceResponse<List<GetVideogameDto>>>> GetGenre(Genres genre)
        {
            return Ok(await _videogameService.GetVideogameByGenre(genre));
        }

        /* Route that retrieves all entries in the database that are under the same age rating. */
        [HttpGet("AgeRatingSearch/{rating}")]
        public async Task<ActionResult<ServiceResponse<List<GetVideogameDto>>>> GetRating(AgeRatings rating)
        {
            return Ok(await _videogameService.GetVideogameByRating(rating));
        }

        /* Route that retrives all entries in the database that are under the same game rating. */
        [HttpGet("GameRatingSearch/{rating}")]
        public async Task<ActionResult<ServiceResponse<List<GetVideogameDto>>>> GetReview(GameRatings rating)
        {
            return Ok(await _videogameService.GetVideogameByReview(rating));
        }

        /* Route that retrieves all entries in the database that are exclusive to a specific platform. */
        [HttpGet("ExclusiveSearch/{exclusive}")]
        public async Task<ActionResult<ServiceResponse<List<GetVideogameDto>>>> GetExclusive(Exclusives exclusive)
        {
            return Ok(await _videogameService.GetVideogameByExclusive(exclusive));
        }

        /* Route that adds an entry into the database. */
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetVideogameDto>>>> Create(AddVideogameDto game)
        {
            return Ok(await _videogameService.AddVideogame(game));
        }

        /* Route that deletes a specific entry in the database when given the ID number. */
        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<List<GetVideogameDto>>>> Delete(int id)
        {
            var response = await _videogameService.DeleteVideogame(id);
            if (response.Data is null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        /* Route that updates a specific entry in the database when given the ID number and updated information. */
        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<GetVideogameDto>>>> Update(UpdateVideogameDto game)
        {
            var response = await _videogameService.UpdateVideogame(game);
            if (response.Data is null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }
    }
}