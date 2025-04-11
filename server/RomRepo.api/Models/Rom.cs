using System.ComponentModel.DataAnnotations;

namespace RomRepo.api.Models
{
    /// <summary>Holds information about an individual ROM file</summary>
    public class Rom
    {
        [Key]
        public int RomID { get; set; }
        public int? GameID { get; set; }
        public Game? Game { get; set; }
        public string? NoIntroGameID { get; set; }
        public required string Name { get; set; }
        public int? Size { get; set; }
        public string? CRC { get; set; }
        public string? MD5 { get; set; }
        public string? SHA1 { get; set; }
        public string? SHA256 { get; set; }
        public string? Status { get; set; }
        public string? Serial { get; set; }
    }
}
