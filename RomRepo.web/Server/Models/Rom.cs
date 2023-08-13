namespace RomRepo.web.Server.Models
{
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
        public bool IsHack { get; set;} = false;


        public int? ParentRomID { get; set; }
        public Rom? ParentRom { get; set; }
    }
}
