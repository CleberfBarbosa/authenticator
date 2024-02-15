using Infra.Domain.Entities;
using Infra.Extensions;

namespace Authenticator.Application.Domain.Entities
{
    public class User : BaseEntity
    {
        public void Validate()
        {
            if (!Email.IsValidEmail())
                throw new ArgumentException("User email is inválid!");

            if (FirstName.IsNullOrEmpty())
                throw new ArgumentException("User first name inválid!");

            if (LastName.IsNullOrEmpty())
                throw new ArgumentException("User last name inválid!");

            if (Birthday == DateTime.MinValue)
                throw new ArgumentException("User birthday inválid!");
        }

        public string Email { get; private set; }
        public string DocumentNumber { get; private set; }
        public string PhoneNumber { get; private set; }
        public bool EmailConfirmed { get; set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public DateTime Birthday { get; private set; }
    }
}
