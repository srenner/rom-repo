using System.ComponentModel.DataAnnotations;

namespace RomRepo.api.Models
{
    /// <summary>Record that a user favorited a game system in their library (part of opt-in analytics)</summary>
    public class GameSystemFavorite
    {
        /// <summary>Database ID for the game system favorite record</summary>
        [Key]
        public int GameSystemFavoriteID { get; set; }
        /// <summary>ID of the API Key associated with the user</summary>
        public int ApiKeyID { get; set; }
        /// <summary>API Key associated with the user</summary>
        public ApiKey ApiKey { get; set; }
        /// <summary>ID of the game system that was favorited</summary>
        public int GameSystemID { get; set; }
        /// <summary>Game system object that was favorited</summary>
        public GameSystem GameSystem { get; set; }
        /// <summary>Date and time the game system was favorited</summary>
        public DateTime DateCreated { get; set; }
    }
}
