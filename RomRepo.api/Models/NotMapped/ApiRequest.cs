using System.Net.Mail;

namespace RomRepo.api.Models.NotMapped
{
    /// <summary>
    /// Input parameters from a client requesting a new API Key. Client must include at least one parameter to receive a key.
    /// </summary>
    public class ApiRequest
    {
        public string? InstallationID { get; set; }
        public string? Email { get; set; }

        public bool CleanAndVerify()
        {
            bool isValid = false;
            if(IsInstallationIDValid())
            {
                isValid = true;
            }    
            else
            {
                InstallationID = "";
            }

            if(IsEmailValid())
            {
                isValid = true;
            }
            else
            {
                Email = "";
            }
            return isValid;
        }

        private bool IsInstallationIDValid()
        {
            return Guid.TryParse(this.InstallationID, out _);
        }

        private bool IsEmailValid()
        {
            return MailAddress.TryCreate(this.Email, out _);
        }
    }
}
