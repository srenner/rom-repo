using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Mail;

namespace RomRepo.api.Models
{
    public class ApiKey
    {
        public int ApiKeyID { get; set; }
        public required string Key { get; set; }
        public string? InstallationID { get; set; }
        public string? Email { get; set; }
        public string? IPAddress { get; set; }
        public bool IsActive { get; set; } = false;
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
    }
}
