using Authenticator.Application.Infra;
using Infra.Extensions;
using Serilog;

try
{
    var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.

    builder.Services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    builder.Services.AddHttpContextAccessor();
    builder.ConfigContextForPostgreSQL<AuthenticatorEfContext>();
    builder.Services.ConfigDependencies();
    builder.ConfigJwks<AuthenticatorEfContext>();
    builder.ConfigAuthJwks();
    builder.ConfigSerilog();
    builder.ConfigSwaggerBearer();

    var app = builder.Build();
    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    // Create a url to uri: https://localhost:<port>/jwks
    app.UseJwksDiscovery();
    app.UseHttpsRedirection();
    app.UseAuthentication();
    app.UseAuthorization();
    app.MapControllers();
    app.UseDefaultMiddewares();
    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Application has stopped!");
}
finally
{
    Log.Information("Application closure.");
    Log.CloseAndFlush();
}