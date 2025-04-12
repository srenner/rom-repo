using System.ComponentModel.DataAnnotations;

namespace RomRepo.api.Models
{
    /// <summary>Holds information about an individual game</summary>
    public class Game
    {
        /// <summary>
        /// ID from RomRepo database
        /// </summary>
        [Key]
        public int GameID { get; set; }
        /// <summary>ID from DAT file</summary>
        public string? NoIntroGameID { get; set; }
        /// <summary>Parent Game ID from RomRepo database</summary>
        public int? ParentGameID { get; set; }
        /// <summary>Parent Game object</summary>
        public Game? ParentGame { get; set; }
        /// <summary>Parent Game ID from DAT file</summary>
        public string? ParentNoIntroID { get; set; }
        /// <summary>ID of the game system this game is associated with</summary>
        public int? GameSystemID { get; set; }
        /// <summary>Game system object</summary>
        public GameSystem? GameSystem { get; set; }
        /// <summary>ID from DAT file for the game system</summary>
        public string? NoIntroGameSystemID { get; set; }
        /// <summary>Name of the game</summary>
        public required string Name { get; set; }
        /// <summary>Description of the game</summary>
        public string? Description { get; set; }

        /// <summary>ROMs associated with this game</summary>
        public IEnumerable<Rom>? Roms { get; set; }
        /// <summary>
        /// Collection of game attributes; see <see cref="GameAttribute"/>"
        /// </summary>
        public IEnumerable<GameAttribute>? Attributes { get; set; }
    }
}
