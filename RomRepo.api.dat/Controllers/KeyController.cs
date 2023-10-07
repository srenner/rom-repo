using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;

namespace RomRepo.api.dat.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KeyController : ControllerBase
    {
        private int _length = 32;
        private string _prefix = "rr-";

        [HttpPost("generate")]
        public string GenerateApiKey([FromBody] string email)
        {
            var requestorIP = HttpContext?.Connection?.RemoteIpAddress?.ToString();

            var bytes = RandomNumberGenerator.GetBytes(_length);
            string base64String = Convert.ToBase64String(bytes)
                .Replace("+", "-")
                .Replace("/", "_");
            var keyLength = _length - _prefix.Length;
            return _prefix + base64String[..keyLength] + " generated for " + requestorIP;
        }

    }
}
