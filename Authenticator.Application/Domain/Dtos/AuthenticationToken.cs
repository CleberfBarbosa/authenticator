namespace Authenticator.Application.Domain.Dtos
{
    public class AuthenticationToken
    {
        public AuthenticationToken(string accessToken, DateTime expiration)
        {
            if (accessToken == null) throw new ArgumentNullException("Inválid token!");

            if (expiration <= DateTime.MinValue) throw new ArgumentOutOfRangeException("Inválid expiration token!");

            AccessToken = accessToken;
            Expiration = expiration;
        }

        public const string Type = "Bearer";
        public string AccessToken { get; set; }
        public DateTime Expiration { get; set; }
    }
}
