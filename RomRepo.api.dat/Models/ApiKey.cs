using System.ComponentModel.DataAnnotations.Schema;

namespace RomRepo.api.dat.Models
{
    public class ApiKey
    {
        public int ApiKeyID { get; set; }
        public required string Key { get; set; }
        public string? InstallationID { get; set; }
        public string? Email { get; set; }
        public string? IPAddress { get; set; }
        public bool IsActive { get; set; } = false;

        [NotMapped]
        public string? ResponseMessage { get; set; }
    }
}
