using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace videogame_api
{
    public class AutoMapperProfile : Profile
    {
        // Profile created to allow for conversion between the data transfer objects and database.
        public AutoMapperProfile()
        {
            CreateMap<Videogame, GetVideogameDto>();
            CreateMap<GetVideogameDto, Videogame>();
            CreateMap<GetVideogameDto, List<Videogame>>();
            CreateMap<AddVideogameDto, Videogame>();
        }
    }
}