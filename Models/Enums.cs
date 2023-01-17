using System.Text.Json.Serialization;

namespace videogame_api.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum AgeRatings
    {
        Everyone = 1,
        EveryoneTenandUp = 2,
        Teen = 3,
        Mature = 4,
        RatingPending = 5
    }
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum GameRatings
    {
        OverwhelminglyPositive = 1,
        VeryPositve = 2,
        Positive = 3,
        MostlyPositive = 4,
        Mixed = 5,
        MostlyNegative = 6,
        Negative = 7,
        VeryNegative = 8,
        OverwhelminglyNegative = 9,
        NoReview = 10
    }
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Exclusives
    {
        PlayStation = 1,
        Xbox = 2,
        Nintendo = 3,
    }
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Genres
    {
        Platformer = 1,
        Shooter = 2,
        Fighting = 3,
        HackandSlash = 4,
        Survival = 5,
        Rhythm = 6,
        Horror = 7,
        RPG = 8

    }
}