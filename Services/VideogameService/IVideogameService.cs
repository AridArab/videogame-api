using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace videogame_api.Services.VideogameService
{
    public interface IVideogameService
    {
        /* Interface that lists all methods for VideogameService. */
        Task<ServiceResponse<List<GetVideogameDto>>> GetAllVideogames();
        Task<ServiceResponse<GetVideogameDto>> GetVideogame(int id);
        Task<ServiceResponse<List<GetVideogameDto>>> AddVideogame(AddVideogameDto newVideogame);
        Task<ServiceResponse<GetVideogameDto>> UpdateVideogame(UpdateVideogameDto updatedVideogame);
        Task<ServiceResponse<List<GetVideogameDto>>> DeleteVideogame(int id);
        Task<ServiceResponse<List<GetVideogameDto>>> GetVideogameByGenre(Genres genre);
        Task<ServiceResponse<List<GetVideogameDto>>> GetVideogameByRating(AgeRatings rating);
        Task<ServiceResponse<List<GetVideogameDto>>> GetVideogameByReview(GameRatings rating);
        Task<ServiceResponse<List<GetVideogameDto>>> GetVideogameByExclusive(Exclusives exclusive);
    }
}