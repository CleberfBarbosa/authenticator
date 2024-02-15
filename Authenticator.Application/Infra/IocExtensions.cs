using Authenticator.Application.Auth;
using Authenticator.Application.Services.Clients;
using Infra.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Authenticator.Application.Infra
{
    public static class IocExtensions
    {
        public static void ConfigDependencies(this IServiceCollection services)
        {
            services.AddScoped<DbContext, AuthenticatorEfContext>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IClientService, ClientService>();
            services.AddScoped<IAuthenticationClient, AuthenticationClientService>();
        }
    }
}
