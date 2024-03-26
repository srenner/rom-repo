using System.ComponentModel.DataAnnotations;

namespace RomRepo.api.Models
{
    /// <summary>
    /// Record that a user favorited a game in their library (part of opt-in analytics)
    /// </summary>
    public class GameFavorite
    {
        [Key]
        public int GameFavoriteID { get; set; }
        public int ApiKeyID { get; set; }
        public ApiKey ApiKey { get; set; }
        public int GameID { get; set; }
        public Game Game { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
