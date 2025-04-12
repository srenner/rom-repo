using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Mail;

namespace RomRepo.api.Models
{
    /// <summary>
    /// API Key for accessing the RomRepo API
    /// </summary>
    public class ApiKey
    {
        /// <summary>ID in database</summary>
        public int ApiKeyID { get; set; }
        public required string Key { get; set; }
        /// <summary>GUID generated from client software</summary>
        public string? InstallationID { get; set; }
        /// <summary>Email address of the user that requested the key</summary>
        public string? Email { get; set; }
        /// <summary>IP Address of the client that requested the key</summary>
        public string? IPAddress { get; set; }
        /// <summary>Status of the API Key; see <see cref="ApiKeyStatus"/></summary>
        public int Status { get; set; } = (int)ApiKeyStatus.Pending;
        /// <summary>Date and time the API Key was created</summary>
        public DateTime DateCreated { get; set; }
        /// <summary>Date and time the API Key was last updated</summary>
        public DateTime DateUpdated { get; set; }
    }
}
