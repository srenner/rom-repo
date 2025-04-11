using System.Net.Mail;

namespace RomRepo.api.Models.NotMapped
{
    /// <summary>
    /// Input parameters from a client requesting a new API Key. Client must include at least one parameter to receive a key.
    /// </summary>
    public class ApiRequest
    {
        /// <summary>GUID generated from client software that is requesting API access</summary>
        public string? InstallationID { get; set; }
        /// <summary>Email address of the user that is requesting API access</summary>
        public string? Email { get; set; }

        /// <summary>Verify the input parameters are in valid format; set to empty string if not</summary>
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
