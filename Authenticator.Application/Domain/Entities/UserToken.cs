using Infra.Domain.Entities;

namespace Authenticator.Application.Domain.Entities
{
    public class UserToken : BaseEntity
    {
        public virtual UserClient UserLogin { get; set; }
        public long UserLoginId { get; set; }
        public DateTime CreationDate { get; set; }
        public string RefreshToken { get; set; }
        public DateTime ExpirationResfreshToken { get; set; }
        public bool Revoked { get; set; }

        public void RevokeToken()
        {
            this.Revoked = true;
        }
    }
}
