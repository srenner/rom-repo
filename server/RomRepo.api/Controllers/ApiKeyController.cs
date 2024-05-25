using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RomRepo.api.DataAccess;
using RomRepo.api.Models;
using RomRepo.api.Models.NotMapped;
using SQLitePCL;
using System.Net;
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
        private ILogger<ApiKeyController> _logger;
        private IApiRepository _apiRepository;

        public ApiKeyController(ILogger<ApiKeyController> logger, IApiRepository apiRepository)
        {
            _logger = logger;
            _apiRepository = apiRepository;
        }

        [AllowAnonymous]
        [HttpPost("generate")]
        public async Task<ActionResult<ApiKey>> GenerateApiKey([FromBody] ApiRequest req)
        {
            if(req.CleanAndVerify())
            {
                var requestorIP = HttpContext?.Connection?.RemoteIpAddress?.ToString();
                var bytes = RandomNumberGenerator.GetBytes(_length);
                string base64String = Convert.ToBase64String(bytes)
                    .Replace("+", "-")
                    .Replace("/", "_");
                var keyLength = _length - _prefix.Length;
                var now = DateTime.UtcNow;
                ApiKey key = new ApiKey
                {
                    Key = _prefix + base64String[..keyLength],
                    Email = req.Email,
                    InstallationID = req.InstallationID,
                    IPAddress = requestorIP,
                    DateCreated = now,
                    DateUpdated = now
                };
                key = await _apiRepository.SaveKey(key);
                return key;
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost("status")]
        public async Task<ActionResult> UpdateKeyStatus([FromBody]ApiKeyValueStatus keyStatus)
        {
            if(keyStatus != null)
            {
                await _apiRepository.SetKeyStatus(keyStatus.Key, (ApiKeyStatus)keyStatus.Status);
                return Ok();
            }
            else
            {
                return StatusCode((int)HttpStatusCode.BadRequest);
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ApiKey>>> GetKey(string source)
        {
            //temporarily disable until admin security defined
            return StatusCode(501);

            if(MailAddress.TryCreate(source, out var mailAddresss))
            {
                var keys = await _apiRepository.GetKeyByEmail(source);
                if (keys != null && keys.Any())
                {
                    return Ok(keys);
                }
                else return NotFound(keys);
            }
            else
            {
                return StatusCode(405);
            }
        }

    }
}
