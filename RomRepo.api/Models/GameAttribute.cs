namespace RomRepo.api.Models
{
    public class GameAttribute
    {
        public int GameAttributeID { get; set; }

        public int GameID { get; set; }
        public Game Game { get; set; }

        public string Value { get; set; } = string.Empty;
        public int SortOrder { get; set; } = 1;
    }
}
