using System.ComponentModel.DataAnnotations;

namespace RomRepo.api.Models
{
    /// <summary>Record that a user has a game in their library (part of opt-in analytics)</summary>
    public class GameInstallation
    {
        /// <summary>Unique identifier for the game installation record</summary>
        [Key]
        public int GameInstallationID { get; set; }
        /// <summary>ID of the game that is installed</summary>
        public int GameID { get; set; }
        /// <summary>Game object that is installed</summary>
        public Game Game { get; set; }
        /// <summary>ID of the API Key associated with the user</summary>
        public int ApiKeyID { get; set; }
        /// <summary>API Key associated with the user</summary>
        public ApiKey ApiKey { get; set; }
        /// <summary>Date and time the game was recorded as installed</summary>
        public DateTime DateCreated { get; set; }
    }
}
