namespace Authenticator.Application.Exceptions
{
    public class ClientNotFoundException : Exception
    {
        public ClientNotFoundException() : base("Cliente não encontrado!")
        {
        }
    }
}
