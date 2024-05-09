namespace RomRepo.api.Models.NotMapped
{
    public class RomInfo
    {
        public string RomName { get; set; }
        public string GameName { get; set; }
        public string? Status { get; set; }
        public string GameSystemName { get; set; }
        public string[] Authors { get; set; }
        public string? Serial { get; set; }
        public int? Size { get; set; }
        public string? CRC { get; set; }
        public string? MD5 { get; set; }
        public string? SHA1 { get; set; }
        public string? SHA256 { get; set; }
    }
}
