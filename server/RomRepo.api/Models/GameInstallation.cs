using System.ComponentModel.DataAnnotations;

namespace RomRepo.api.Models
{
    /// <summary>Record that a user has a game in their library (part of opt-in analytics)</summary>
    public class GameInstallation
    {
        [Key]
        public int GameInstallationID { get; set; }
        public int GameID { get; set; }
        public Game Game { get; set; }
        public int ApiKeyID { get; set; }
        public ApiKey ApiKey { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
