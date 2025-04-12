namespace RomRepo.api.Models
{
    /// <summary>Game attribute model</summary>
    public class GameAttribute
    {
        /// <summary>ID from RomRepo database</summary>
        public int GameAttributeID { get; set; }

        /// <summary>ID of the game this attribute is associated with</summary>
        public int GameID { get; set; }
        /// <summary>Game object this attribute is associated with</summary>
        public Game Game { get; set; }

        /// <summary>Value of the attribute</summary>
        public string Value { get; set; } = string.Empty;
        /// <summary>Sort order for the attribute</summary>
        public int SortOrder { get; set; } = 1;
    }
}
