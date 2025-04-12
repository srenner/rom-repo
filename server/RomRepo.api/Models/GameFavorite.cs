using System.ComponentModel.DataAnnotations;

namespace RomRepo.api.Models
{
    /// <summary>Record that a user favorited a game in their library (part of opt-in analytics)</summary>
    public class GameFavorite
    {
        /// <summary>Database ID for the game favorite record</summary>
        [Key]
        public int GameFavoriteID { get; set; }
        /// <summary>ID of the API Key associated with the user</summary>
        public int ApiKeyID { get; set; }
        /// <summary>API Key associated with the user</summary>
        public ApiKey ApiKey { get; set; }
        /// <summary>ID of the game that was favorited</summary>
        public int GameID { get; set; }
        /// <summary>Game object that was favorited</summary>
        public Game Game { get; set; }
        /// <summary>Date and time the game was favorited</summary>
        public DateTime DateCreated { get; set; }
    }
}
