using Authenticator.Application.Domain.Dtos;
using Authenticator.Application.Services.Clients;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using NetDevPack.Security.Jwt.Core.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Authenticator.Application.Auth
{
    public class AuthenticationClientService : IAuthenticationClient
    {
        private readonly IClientService clientService;
        private readonly IJwtService jwtService;
        private readonly IHttpContextAccessor httpContextAccessor;

        public AuthenticationClientService(IClientService clientService,
            IJwtService jwtService,
            IHttpContextAccessor httpContextAccessor)
        {
            this.clientService = clientService;
            this.jwtService = jwtService;
            this.httpContextAccessor = httpContextAccessor;
        }

        public AuthenticationToken Authenticate(ClientSignIn clientSignIn)
        {
            var client = clientService
                .Get(clientSignIn.ClientId, clientSignIn.ClientSecret);
            var tokenJwt = GenerateToken(
                new ClaimsIdentity(
                    new List<Claim>
                    {
                        new Claim("identifier", client.Identifier)
                    }));

            return new AuthenticationToken(tokenJwt, DateTime.UtcNow.AddHours(1));
        }

        private string GenerateToken(ClaimsIdentity claims)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var currentIssuer = $"{httpContextAccessor.HttpContext.Request.Scheme}://{httpContextAccessor.HttpContext.Request.Host}";

            var key = jwtService.GetCurrentSigningCredentials();
            var token = tokenHandler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = currentIssuer,
                Subject = claims,
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = key.Result
            });
            return tokenHandler.WriteToken(token);
        }
    }
}
