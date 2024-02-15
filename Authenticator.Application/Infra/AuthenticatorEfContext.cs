using Microsoft.EntityFrameworkCore;
using NetDevPack.Security.Jwt.Core.Model;
using NetDevPack.Security.Jwt.Store.EntityFrameworkCore;
using System.Reflection;

namespace Authenticator.Application.Infra
{
    public class AuthenticatorEfContext : DbContext, ISecurityKeyContext
    {
        public AuthenticatorEfContext(DbContextOptions<AuthenticatorEfContext> options) : base(options)
        {
        }

        public DbSet<KeyMaterial> SecurityKeys { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresExtension("uuid-ossp");
            modelBuilder.ApplyConfiguration(new KeyMaterialMap());
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());            
            base.OnModelCreating(modelBuilder);
        }
    }
}
