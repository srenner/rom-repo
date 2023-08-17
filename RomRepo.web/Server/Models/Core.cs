namespace RomRepo.web.Server.Models
{
    /// <summary>
    /// A Core is a video game console or computer system, i.e. SNES, Genesis, Commodore 64, etc.
    /// </summary>
    public class Core
    {
        public int CoreID { get; set; }

        public required string Path { get; set; }

        /// <summary>
        /// Automatically provided by the path, but can be renamed by the user
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// Use if the name alone isn't clear enough
        /// </summary>
        public string? Description { get; set; }


        /// <summary>
        /// Specifies if a zip file contained in the core's folder is considered a ROM file.
        /// </summary>
        public bool ZipAsRom { get; set; } = false;

        /// <summary>
        /// Specifies if a 7z file contained in the core's folder is considered a ROM file.
        /// </summary>
        public bool SevenZipAsRom { get; set; }

        /// <summary>
        /// Specifies if folder contained in the core's folder is considered a ROM.
        /// For example, a folder is typically used in CD-based systems with bin/cue files to make up a ROM.
        /// </summary>
        public bool FolderAsRom { get; set;} = false;

        /// <summary>
        /// Comma separated list of valid file extensions for this core.
        /// </summary>
        public string? FileExtensions { get; set; }

        public bool IsFavorite { get; set; } = false;
        public bool IsActive { get; set; } = true;

        public ICollection<Rom>? Roms { get; set; }

    }
}
