using System.ComponentModel.DataAnnotations;

namespace RomRepo.api.Models
{
    /// <summary>Holds information about an individual game</summary>
    public class Game
    {
        [Key]
        public int GameID { get; set; }
        /// <summary>ID from DAT file</summary>
        public string? NoIntroGameID { get; set; }
        public int? ParentGameID { get; set; }
        public Game? ParentGame { get; set; }
        public string? ParentNoIntroID { get; set; }
        public int? GameSystemID { get; set; }
        public GameSystem? GameSystem { get; set; }
        public string? NoIntroGameSystemID { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }

        public IEnumerable<Rom>? Roms { get; set; }
        public IEnumerable<GameAttribute>? Attributes { get; set; }
    }
}
