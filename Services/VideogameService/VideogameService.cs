using System.Reflection.Emit;
using System.Runtime.InteropServices;
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
            new Videogame()
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
            serviceResponse.Message = "Entries successfully loaded.";
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetVideogameDto>> GetVideogame(int id)
        {
            var serviceResponse = new ServiceResponse<GetVideogameDto>();
            var dbVideogame = await _context.Videogames.FirstOrDefaultAsync(g => g.Id == id);
            serviceResponse.Data = _mapper.Map<GetVideogameDto>(dbVideogame);
            serviceResponse.Message = "Entry successfully loaded.";
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetVideogameDto>>> AddVideogame(AddVideogameDto game)
        {
            var serviceResponse = new ServiceResponse<List<GetVideogameDto>>();
            var newGame = _mapper.Map<Videogame>(game);
            await _context.Videogames.AddAsync(newGame);
            await _context.SaveChangesAsync();
            serviceResponse.Data = games.Select(g => _mapper.Map<GetVideogameDto>(g)).ToList();
            serviceResponse.Message = "Entry successfully created.";
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
                    serviceResponse.Message = "Entry successfully Deleted.";
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
                serviceResponse.Message = "Entry successfully updated.";
            }

            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            
            return serviceResponse;

        }

        public async Task<ServiceResponse<List<GetVideogameDto>>> GetVideogameByGenre(Genres genre)
        {
            var serviceResponse = new ServiceResponse<List<GetVideogameDto>>();
            

            try {
                var games = await _context.Videogames.Where(g => g.Genre == genre).ToListAsync();
                if (games == null)
                {
                    throw new Exception($"Genre '{genre}' is either not found in database or not valid, Please try again.");
                }

                serviceResponse.Data = _mapper.Map<List<GetVideogameDto>>(games);
                serviceResponse.Message = "Entries successfully loaded.";
            }

            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
        
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetVideogameDto>>> GetVideogameByRating(AgeRatings rating)
        {
            var serviceResponse = new ServiceResponse<List<GetVideogameDto>>();
            

            try {
                var games = await _context.Videogames.Where(g => g.AgeRating == rating).ToListAsync();
                if (games == null)
                {
                    throw new Exception($"Age rating '{rating}' is either not found in database or not valid, Please try again.");
                }

                serviceResponse.Data = _mapper.Map<List<GetVideogameDto>>(games);
                serviceResponse.Message = "Entries successfully loaded.";
            }

            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
        
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetVideogameDto>>> GetVideogameByReview(GameRatings rating)
        {
            var serviceResponse = new ServiceResponse<List<GetVideogameDto>>();


            try {
                var games = await _context.Videogames.Where(g => g.GameRating == rating).ToListAsync();
                if (games == null)
                {
                    throw new Exception($"Game rating '{rating}' is either not found in database or not valid, Please try again.");
                }

                serviceResponse.Data = _mapper.Map<List<GetVideogameDto>>(games);
                serviceResponse.Message = "Entries successfully loaded.";
            }

            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetVideogameDto>>> GetVideogameByExclusive(Exclusives exclusive)
        {
            var serviceResponse = new ServiceResponse<List<GetVideogameDto>>();


            try {
                var games = await _context.Videogames.Where(g => g.Exclusive == exclusive).ToListAsync();
                if (games == null)
                {
                    throw new Exception($"Exclusivity '{exclusive}' is either not found in database or not valid, Please try again.");
                }

                serviceResponse.Data = _mapper.Map<List<GetVideogameDto>>(games);
                serviceResponse.Message = "Entries successfully loaded.";
            }

            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }
    }
}