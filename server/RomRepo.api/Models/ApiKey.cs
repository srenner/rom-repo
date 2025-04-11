using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Mail;

namespace RomRepo.api.Models
{
    /// <summary>
    /// API Key for accessing the RomRepo API
    /// </summary>
    public class ApiKey
    {
        public int ApiKeyID { get; set; }
        public required string Key { get; set; }
        /// <summary>GUID generated from client software</summary>
        public string? InstallationID { get; set; }
        public string? Email { get; set; }
        public string? IPAddress { get; set; }
        public int Status { get; set; } = (int)ApiKeyStatus.Pending;
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
    }
}
