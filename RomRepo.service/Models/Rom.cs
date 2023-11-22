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
        /// Patched rom, i.e. fan translation, rom hack, etc. Can use ParentRomID to specify original game.
        /// </summary>
        public bool IsPatch { get; set; } = false;


        public int? ParentRomID { get; set; }
        public Rom? ParentRom { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }


        public bool Extract()
        {
            return false;
        }

        public bool Compress()
        {
            return false;
        }
    }
}
