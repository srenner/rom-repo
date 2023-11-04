using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RomRepo.api.Models;
using RomRepo.api.Models.NotMapped;
using System.Net.Mail;
using System.Security.Cryptography;

namespace RomRepo.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiKeyController : ControllerBase
    {
        private int _length = 32;
        private string _prefix = "rr-";

        [HttpPost("generate")]
        public ActionResult<ApiKey> GenerateApiKey([FromBody] ApiRequest req)
        {
            if(req.IsInstallationIDValid() || req.IsEmailValid())
            {
                var requestorIP = HttpContext?.Connection?.RemoteIpAddress?.ToString();
                var bytes = RandomNumberGenerator.GetBytes(_length);
                string base64String = Convert.ToBase64String(bytes)
                    .Replace("+", "-")
                    .Replace("/", "_");
                var keyLength = _length - _prefix.Length;

                ApiKey key = new ApiKey
                {
                    Key = _prefix + base64String[..keyLength],
                    Email = req.Email,
                    InstallationID = req.InstallationID,
                    IPAddress = requestorIP
                };

                //todo insert

                return key;
            }
            else
            {
                return BadRequest();
            }
        }

        

    }
}
