using System.ComponentModel.DataAnnotations;

namespace RomRepo.api.Models
{
    /// <summary>Record that a user favorited a game system in their library (part of opt-in analytics)</summary>
    public class GameSystemFavorite
    {
        [Key]
        public int GameSystemFavoriteID { get; set; }
        public int ApiKeyID { get; set; }
        public ApiKey ApiKey { get; set; }
        public int GameSystemID { get; set; }
        public GameSystem GameSystem { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
