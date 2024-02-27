using System.ComponentModel.DataAnnotations;

namespace RomRepo.api.Models
{
    public class Game
    {
        [Key]
        public int GameID { get; set; }
        /// <summary>
        /// ID from DAT file
        /// </summary>
        public int? NoIntroGameID { get; set; }
        
        public int? ParentGameID { get; set; }
        public Game? ParentGame { get; set; }
        
        public int? ParentNoIntroID { get; set; }
        
        public int? GameSystemID { get; set; }
        public GameSystem? GameSystem { get; set; }

        public int? NoIntroGameSystemID { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }

        public IEnumerable<Rom>? Roms { get; set; }
    }
}
