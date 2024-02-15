using Authenticator.Application.Domain.Dtos;
using Authenticator.Application.Domain.Entities;

namespace Authenticator.Application.Services.Clients
{
    public interface IClientService
    {
        ClientSignUpResponse Create(ClientSignUpRequest clientSignUpRequest);
        Client Get(string clientId, string clienteSecret);
    }
}
