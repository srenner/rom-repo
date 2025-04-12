using System.ComponentModel.DataAnnotations;

namespace RomRepo.api.Models
{
    /// <summary>Holds information about a video game system</summary>
    public class GameSystem
    {
        /// <summary>
        /// ID from RomRepo database
        /// </summary>
        [Key]
        public int GameSystemID { get; set; }
        /// <summary>ID from DAT file</summary>
        public string? NoIntroGameSystemID { get; set; }
        /// <summary>sName of the game system</summary>
        public required string Name { get; set; }
        /// <summary>Description of the game system</summary>
        public string? Description { get; set; }
        /// <summary>Version of the game system</summary>
        public string? Version { get; set; }
        /// <summary>Comma delimited string of No-Intro authors</summary>
        public string? Author { get; set; }
        /// <summary>Title text for No-Intro link</summary>
        public string? Homepage { get; set; }
        /// <summary>No-Intro URL</summary>
        public string? URL { get; set; }

        /// <summary>Games associated with this game system</summary>
        public IEnumerable<Game>? Games { get; set; }
    }
}
