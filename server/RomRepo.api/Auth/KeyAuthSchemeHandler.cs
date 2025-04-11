using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using RomRepo.api.Services;
using System.Security.Claims;
using System.Text.Encodings.Web;

namespace RomRepo.api.Auth
{
    /// <summary>Authentication handler for API key</summary>
    public class KeyAuthSchemeHandler : AuthenticationHandler<KeyAuthSchemeOptions>
    {
        private readonly ILogger<KeyAuthSchemeHandler> _logger;
        private readonly IApiKeyService _apiKeyService;

        public KeyAuthSchemeHandler(IOptionsMonitor<KeyAuthSchemeOptions> options, ILoggerFactory logger, UrlEncoder encoder, IRomService romService, IApiKeyService apiKeyService) 
            : base(options, logger, encoder)
        {
            _logger = logger.CreateLogger<KeyAuthSchemeHandler>();
            _apiKeyService = apiKeyService;
        }

        protected async override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            bool isSuccess = false;

            string? keyValue = this.Context.Request.Headers.FirstOrDefault(w => w.Key.ToLower() == "x-api-key").Value;
            string requestedURL = this.CurrentUri;
            string ip = "";
            var keyStatus = ApiKeyStatus.Unknown;

            if(keyValue?.Length > 0)
            {
                keyStatus =  await _apiKeyService.GetKeyStatus(keyValue);
                switch (keyStatus)
                {
                    case ApiKeyStatus.Active:
                        isSuccess = true;
                        break;
                    case ApiKeyStatus.Pending:
                        _logger.LogInformation("User attempted request with Pending key.");
                        break;
                    case ApiKeyStatus.Inactive:
                        _logger.LogWarning("User attempted request with Inactive key.");
                        break;
                    case ApiKeyStatus.Unknown:
                        _logger.LogError("User attempted request with Unknown key.");
                        break;
                }
                if (isSuccess)
                {
                    var claims = new[] { new Claim(ClaimTypes.Name, "ApiKey") };
                    var principal = new ClaimsPrincipal(new ClaimsIdentity(claims, "Key"));
                    var ticket = new AuthenticationTicket(principal, this.Scheme.Name);
                    return AuthenticateResult.Success(ticket);
                }
                else
                {
                    return AuthenticateResult.Fail("Invalid API Key");
                }
            }
            return AuthenticateResult.Fail("Must include X-API-KEY header.");
        }
    }
}
