using Infra.Extensions;

namespace Authenticator.Application.Domain.Dtos
{
    public class ClientSignUpResponse
    {
        public ClientSignUpResponse(string clientId, string clientSecret)
        {
            if (clientId.IsNullOrEmpty() || clientSecret.IsNullOrEmpty())
                throw new ArgumentException("Invalid credentials");

            ClientId = clientId;
            ClientSecret = clientSecret;
        }

        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
    }
}
