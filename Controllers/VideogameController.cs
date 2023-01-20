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
        public async Task<ActionResult<ServiceResponse<List<GetVideogameDto>>>> GetAll()
        {
            return Ok(await _videogameService.GetAllVideogames());
        }
        [HttpGet("id")]
        public async Task<ActionResult<ServiceResponse<GetVideogameDto>>> Get(int id)
        {
            return Ok(await _videogameService.GetVideogame(id));
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetVideogameDto>>>> Create(AddVideogameDto game)
        {
            return Ok(await _videogameService.AddVideogame(game));
        }
        [HttpDelete("id")]
        public async Task<ActionResult<ServiceResponse<List<GetVideogameDto>>>> Delete(int id)
        {
            var response = await _videogameService.DeleteVideogame(id);
            if (response.Data is null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

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