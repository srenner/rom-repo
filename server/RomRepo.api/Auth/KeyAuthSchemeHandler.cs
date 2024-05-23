using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using RomRepo.api.Services;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Security.Claims;
using System.Text.Encodings.Web;

namespace RomRepo.api.Auth
{
    public class KeyAuthSchemeHandler : AuthenticationHandler<KeyAuthSchemeOptions>
    {
        //sprivate readonly IService _service;
        public KeyAuthSchemeHandler(IOptionsMonitor<KeyAuthSchemeOptions> options, ILoggerFactory logger, UrlEncoder encoder, IRomService romService) 
            : base(options, logger, encoder)
        {

        }

        protected async override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            bool isSuccess = true;

            // check for key
            
            if(isSuccess)
            {
                var claims = new[] { new Claim(ClaimTypes.Name, "ApiKey") };
                var principal = new ClaimsPrincipal(new ClaimsIdentity(claims, "Tokens"));
                var ticket = new AuthenticationTicket(principal, this.Scheme.Name);
                return AuthenticateResult.Success(ticket);
            }
            else
            {
                return AuthenticateResult.Fail("Invalid API Key");
            }

            

            // If the token is missing or the session is invalid, return failure:
        }
    }
}
