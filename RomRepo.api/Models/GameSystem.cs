using System.ComponentModel.DataAnnotations;

namespace RomRepo.api.Models
{
    public class GameSystem
    {
        [Key]
        public int GameSystemID { get; set; }
        /// <summary>
        /// ID from DAT file
        /// </summary>
        public int NoIntroGameSystemID { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public string? Version { get; set; }
        /// <summary>
        /// Comma delimited string of No-Intro authors
        /// </summary>
        public string? Author { get; set; }
        /// <summary>
        /// Title text for No-Intro link
        /// </summary>
        public string? Homepage { get; set; }
        /// <summary>
        /// No-Intro URL
        /// </summary>
        public string? URL { get; set; }

        public IEnumerable<Game>? Games { get; set; }
    }
}
