using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace videogame_api.Services.VideogameService
{
    public interface IVideogameService
    {
        Task<ServiceResponse<List<Videogame>>> GetAllVideogames();
        Task<ServiceResponse<Videogame>> GetVideogame(int id);
        Task<ServiceResponse<List<Videogame>>> AddVideogame(Videogame newVideogame);
        Task<ServiceResponse<List<Videogame>>> DeleteVideogame(int id);
    }
}