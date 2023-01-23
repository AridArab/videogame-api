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
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public VideogameService(IMapper mapper, DataContext context)
        {
            _context = context;
            _mapper = mapper;
        }


        public async Task<ServiceResponse<List<GetVideogameDto>>> GetAllVideogames()
        {
            var serviceResponse = new ServiceResponse<List<GetVideogameDto>>();
            var dbVideogames = await _context.Videogames.ToListAsync();
            serviceResponse.Data = dbVideogames.Select(g => _mapper.Map<GetVideogameDto>(g)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetVideogameDto>> GetVideogame(int id)
        {
            var serviceResponse = new ServiceResponse<GetVideogameDto>();
            var dbVideogame = await _context.Videogames.FirstOrDefaultAsync(g => g.Id == id);
            serviceResponse.Data = _mapper.Map<GetVideogameDto>(dbVideogame);
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetVideogameDto>>> AddVideogame(AddVideogameDto game)
        {
            var serviceResponse = new ServiceResponse<List<GetVideogameDto>>();
            var newGame = _mapper.Map<Videogame>(game);
            await _context.Videogames.AddAsync(newGame);
            await _context.SaveChangesAsync();
            games.Add(_mapper.Map<Videogame>(newGame));
            serviceResponse.Data = games.Select(g => _mapper.Map<GetVideogameDto>(g)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetVideogameDto>>> DeleteVideogame(int id)
        {
            var serviceResponse = new ServiceResponse<List<GetVideogameDto>>();

            try 
            {
                var game =  await _context.Videogames.Where(g => g.Id == id).FirstOrDefaultAsync();
                if (game is null)
                {
                    throw new Exception($"Videogame with id '{id}' not found.");
                }
                else
                {
                    _context.Videogames.Remove(game);
                    await _context.SaveChangesAsync();
                    var games = await _context.Videogames.ToListAsync();
                    serviceResponse.Data =  games.Select(g => _mapper.Map<GetVideogameDto>(g)).ToList();
                }
                

                
            }

            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
            
        }





        public async Task<ServiceResponse<GetVideogameDto>> UpdateVideogame(UpdateVideogameDto updatedVideogame)
        {
            var serviceResponse = new ServiceResponse<GetVideogameDto>();

            try {
            var game = await _context.Videogames.FirstOrDefaultAsync(g => g.Id == updatedVideogame.Id);
            if (game is null)
            {
                throw new Exception($"Videogame with id '{updatedVideogame.Id}' not found.");
            }
            

            game.Name = updatedVideogame.Name;
            game.Genre = updatedVideogame.Genre;
            game.Multiplayer = updatedVideogame.Multiplayer;
            game.AgeRating = updatedVideogame.AgeRating;
            game.GameRating = updatedVideogame.GameRating;
            game.Exclusive = updatedVideogame.Exclusive;
            await _context.SaveChangesAsync();

            serviceResponse.Data = _mapper.Map<GetVideogameDto>(game);
            }

            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;

        }

        /*async Task<ServiceResponse<List<GetVideogameDto>>> IVideogameService.GetVideogameByGenre(Genres genre)
        {
            var serviceResponse = new ServiceResponse<GetVideogameDto>();
            var games = await _context.Videogames.ToListAsync();

            try {
                specificGames = await _context.Videogames.
            }
        }*/
    }
}