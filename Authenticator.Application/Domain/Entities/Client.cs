using Authenticator.Application.Domain.Dtos;
using Infra.Domain.Entities;
using Infra.Extensions;

namespace Authenticator.Application.Domain.Entities
{
    public class Client : BaseEntity
    {
        public Client(ClientSignUpRequest clientSignUpRequest)
        {
            this.Name = clientSignUpRequest.Name;
            this.Email = clientSignUpRequest.Email;
            this.DocumentNumber = clientSignUpRequest.DocumentNumber;
            Validate();
        }

        public Client(string name, string email, string documentNumber)
        {
            this.Email = email;
            this.Name = name;
            this.DocumentNumber = documentNumber;
            Validate();
        }

        public Client()
        {
            
        }

        private void Validate()
        {
            if (!Email.IsValidEmail())
                throw new ArgumentNullException("Client email invalid!");

            if (string.IsNullOrEmpty(Name))
                throw new ArgumentNullException("Client name invalid!");

            if (string.IsNullOrEmpty(DocumentNumber))
                throw new ArgumentNullException("Client document invalid!");
        }

        public void UpdateCredentials()
        {
            this.ClientId = Guid.NewGuid().ToString();
            this.ClientSecret = Guid.NewGuid().ToString();
        }

        public string ClientId { get; set; } = Guid.NewGuid().ToString();
        public string ClientSecret { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string DocumentNumber { get; private set; }
    }
}
