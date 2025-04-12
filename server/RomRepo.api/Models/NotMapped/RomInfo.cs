namespace RomRepo.api.Models.NotMapped
{
    /// <summary>Non-mapped object to hold ROM information</summary>
    public class RomInfo
    {
        /// <summary>Name of ROM file</summary>
        public string RomName { get; set; }
        /// <summary>Name of the game the ROM is part of</summary>
        public string GameName { get; set; }
        /// <summary>
        /// Status of the ROM (e.g. verified, baddump)
        /// </summary>
        public string? Status { get; set; }
        /// <summary>Name of the game system the ROM is associated with</summary>
        public string GameSystemName { get; set; }
        /// <summary>Authors who originally compiled this information</summary>
        public string[] Authors { get; set; }
        /// <summary>Serial number of the ROM</summary>
        public string? Serial { get; set; }
        /// <summary>Size of the ROM file in bytes</summary>
        public int? Size { get; set; }
        /// <summary>CRC checksum for the ROM file</summary>
        public string? CRC { get; set; }
        /// <summary>MD5 checksum for the ROM file</summary>
        public string? MD5 { get; set; }
        /// <summary>SHA1 checksum for the ROM file</summary>
        public string? SHA1 { get; set; }
        /// <summary>SHA256 checksum for the ROM file</summary>
        public string? SHA256 { get; set; }
    }
}
