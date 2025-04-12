using System.ComponentModel.DataAnnotations;

namespace RomRepo.api.Models
{
    /// <summary>Holds information about an individual ROM file</summary>
    public class Rom
    {
        /// <summary>ID from RomRepo database</summary>
        [Key]
        public int RomID { get; set; }
        /// <summary>Database ID of the game associated with the ROM</summary>
        public int? GameID { get; set; }
        /// <summary>Game object associated with the ROM</summary>
        public Game? Game { get; set; }
        /// <summary>ID from DAT file</summary>
        public string? NoIntroGameID { get; set; }
        /// <summary>Name of the ROM file</summary>
        public required string Name { get; set; }
        /// <summary>ROM file size in bytes</summary>
        public int? Size { get; set; }
        /// <summary>CRC checksum for the ROM file</summary>
        public string? CRC { get; set; }
        /// <summary>MD5 checksum for the ROM file</summary>
        public string? MD5 { get; set; }
        /// <summary>SHA1 checksum for the ROM file</summary>
        public string? SHA1 { get; set; }
        /// <summary>SHA256 checksum for the ROM file</summary>
        public string? SHA256 { get; set; }
        /// <summary>Status of the ROM (e.g. verified, baddump)</summary>
        public string? Status { get; set; }
        /// <summary>sSerial number of the ROM</summary>
        public string? Serial { get; set; }
    }
}
