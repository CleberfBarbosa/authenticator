using Authenticator.Application.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Authenticator.Application.Domain.Mappings
{
    public class ClientMapping : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.Property(p => p.ClientId).IsRequired().HasDefaultValueSql("uuid_generate_v4()"); 
            builder.Property(p => p.ClientSecret).IsRequired().HasDefaultValueSql("uuid_generate_v4()");
        }
    }
}
