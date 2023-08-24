namespace RomRepo.web.Server.Models.JSON
{
    public class Alias
    {
        public required string PreferredName { get; set; }
        public required string[] AliasNames { get; set; }
    }
}
