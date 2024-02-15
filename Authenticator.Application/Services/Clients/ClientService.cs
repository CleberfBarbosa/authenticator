using Authenticator.Application.Domain.Dtos;
using Authenticator.Application.Domain.Entities;
using Authenticator.Application.Exceptions;
using Infra.Repository;

namespace Authenticator.Application.Services.Clients
{
    public class ClientService : IClientService
    {
        private readonly IRepository<Client> clientRepository;

        public ClientService(IRepository<Client> clientRepository)
        {
            this.clientRepository = clientRepository;
        }

        public ClientSignUpResponse Create(ClientSignUpRequest clientSignUpRequest)
        {
            var client = new Client(clientSignUpRequest);
            if (clientRepository.Filter(f => f.DocumentNumber == client.DocumentNumber).Any())
                throw new InvalidOperationException("Cliente já existente!");

            clientRepository.Upsert(client);
            return new ClientSignUpResponse(client.ClientId, client.ClientSecret);
        }

        public Client Get(string clientId, string clienteSecret)
        {
            var client = clientRepository
                .Filter(f =>
                    f.ClientId == clientId &&
                    f.ClientSecret == clienteSecret)
                .FirstOrDefault();
            if (client == null)
                throw new ClientNotFoundException();
            return client;
        }
    }
}
