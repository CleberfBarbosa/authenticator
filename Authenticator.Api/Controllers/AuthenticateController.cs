using Authenticator.Application.Auth;
using Authenticator.Application.Domain.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Authenticator.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly IAuthenticationClient authenticationClient;

        public AuthenticateController(IAuthenticationClient authenticationClient)
        {
            this.authenticationClient = authenticationClient;
        }

        [HttpPost("client")]
        public IActionResult Client(ClientSignIn clientSignIn)
        {
            var tokenAcess = authenticationClient.Authenticate(clientSignIn);
            return Ok(tokenAcess);
        }
    }
}
