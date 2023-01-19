using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace videogame_api.Services.VideogameService
{
    public class VideogameService : IVideogameService
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
        async Task<ServiceResponse<List<Videogame>>> IVideogameService.AddVideogame(Videogame game)
        {
            var serviceResponse = new ServiceResponse<List<Videogame>>();
            games.Add(game);
            serviceResponse.Data = games;
            return serviceResponse;
        }

        async Task<ServiceResponse<List<Videogame>>> IVideogameService.DeleteVideogame(int id)
        {
            var serviceResponse = new ServiceResponse<List<Videogame>>();
            var game = games.FirstOrDefault(g => g.Id == id);
            games.Remove(game);
            serviceResponse.Data = games;
            return serviceResponse;
            
        }

        async Task<ServiceResponse<List<Videogame>>> IVideogameService.GetAllVideogames()
        {
            var serviceResponse = new ServiceResponse<List<Videogame>>();
            serviceResponse.Data = games;
            return serviceResponse;
        }

        async Task<ServiceResponse<Videogame>> IVideogameService.GetVideogame(int id)
        {
            var serviceResponse = new ServiceResponse<Videogame>();
            var game = games.FirstOrDefault(g => g.Id == id);
            serviceResponse.Data = game;
            return serviceResponse;
        }
    }
}