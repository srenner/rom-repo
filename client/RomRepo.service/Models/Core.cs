using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RomRepo.service;

namespace RomRepo.console.Models
{
    /// <summary>
    /// A Core is a video game system, named after the concept of a FPGA Core
    /// </summary>
    [Index(nameof(Path), IsUnique = true)]
    public class Core : IFileScannable
    {
        public int CoreID { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }

        public required string Path { get; set; }

        /// <summary>
        /// Can this core treat a .zip file as a valid Rom?
        /// </summary>
        public bool ZipAsRom { get; set; }

        /// <summary>
        /// /// Can this core treat a .7z file as a valid Rom?
        /// </summary>
        public bool SevenZipAsRom { get; set; }

        /// <summary>
        /// Comma separated list of valid file extensions for this core.
        /// </summary>
        public string FileExtensions { get; set; }

        public bool IsFavorite { get; set; } = false;
        public bool IsActive { get; set; } = true;

        public ICollection<Rom> Roms { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }

        public string GetPath()
        {
            return this.Path;
        }

        public DateTime GetLastUpdated()
        {
            return this.DateUpdated;
        }
    }
}
