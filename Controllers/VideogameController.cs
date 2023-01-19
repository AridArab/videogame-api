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
        private readonly IVideogameService _videogameService;

        public VideogameController(IVideogameService videogameService)
        {
            _videogameService = videogameService;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<Videogame>>>> GetAll()
        {
            return Ok(await _videogameService.GetAllVideogames());
        }
        [HttpGet("id")]
        public async Task<ActionResult<ServiceResponse<Videogame>>> Get(int id)
        {
            return Ok(await _videogameService.GetVideogame(id));
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<Videogame>>>> Create(Videogame game)
        {
            return Ok(await _videogameService.AddVideogame(game));
        }
        [HttpDelete("id")]
        public async Task<ActionResult<ServiceResponse<Videogame>>> Delete(int id)
        {
            return Ok(await _videogameService.DeleteVideogame(id));
        }
    }
}