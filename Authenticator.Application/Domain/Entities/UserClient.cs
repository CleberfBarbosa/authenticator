using Infra.Domain.Entities;
using Infra.Extensions;

namespace Authenticator.Application.Domain.Entities
{
    /// <summary>
    /// Referência ao usuario que está realizando o login e a plataforma consumidora do serviço de autenticação
    /// </summary>
    public class UserClient : BaseEntity
    {
        public void RevokeAccess()
        {
            this.Revoked = true;
        }

        public void ChangePassword(string newPassword)
        {
            if (newPassword.IsNullOrEmpty() || newPassword.Length <= 6)
                throw new ArgumentException("User password inválid!");

            Password = newPassword.HashSha256();
        }

        public virtual User User { get; set; }
        public long UserId { get; set; }
        public virtual Client Client { get; set; }
        public long ClientId { get; set; }
        public DateTime CreationDate { get; set; }
        public string Password { get; set; }
        public bool Revoked { get; set; }
    }
}

