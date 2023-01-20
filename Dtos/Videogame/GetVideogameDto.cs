using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace videogame_api.Dtos.Videogame
{
    public class GetVideogameDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public Genres Genre { get; set; } = Genres.Platformer;
        public bool Multiplayer { get; set; } = false;
        public AgeRatings AgeRating { get; set; } = AgeRatings.RatingPending;
        public GameRatings GameRating { get; set; } = GameRatings.NoReview;
        public Exclusives? Exclusive { get; set; }
    }
}