using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomRepo.console.Models
{
    /// <summary>
    /// Represents a single game (a single file, a folder, or a 7z/zip)
    /// </summary>
    public class Rom
    {
        public int RomID { get; set; }

        public int? CoreID { get; set; }
        public Core? Core { get; set; }

        public required string Path { get; set; }

        public bool IsFavorite { get; set; } = false;
        public int? StarRating { get; set; }
        public bool IsActive { get; set; } = true;

        /// <summary>
        /// Used to flag a ROM as a hacked version of a different game. Can use ParentRomID to specify original game.
        /// </summary>
        public bool IsHack { get; set; } = false;


        public int? ParentRomID { get; set; }
        public Rom? ParentRom { get; set; }
    }
}
