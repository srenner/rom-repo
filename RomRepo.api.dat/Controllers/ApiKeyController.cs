using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RomRepo.api.dat.Models;
using RomRepo.api.dat.Models.NotMapped;
using System.Security.Cryptography;

namespace RomRepo.api.dat.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiKeyController : ControllerBase
    {
        private int _length = 32;
        private string _prefix = "rr-";

        [HttpPost("generate")]
        public ApiKey GenerateApiKey([FromBody] ApiRequest req)
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

            return key;
        }

    }
}
