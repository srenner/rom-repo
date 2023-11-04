using System.Net.Mail;

namespace RomRepo.api.dat.Models.NotMapped
{
    /// <summary>
    /// Input parameters from a client requesting a new API Key. Client must include at least one parameter to receive a key.
    /// </summary>
    public class ApiRequest
    {
        public string? InstallationID { get; set; }
        public string? Email { get; set; }

        public bool IsInstallationIDValid()
        {
            return Guid.TryParse(this.InstallationID, out _);
        }

        public bool IsEmailValid()
        {
            return MailAddress.TryCreate(this.Email, out _);
        }
    }
}
