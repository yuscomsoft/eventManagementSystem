using EventManagment.Application;
using EventManagment.Application.Common.Gateway;
using EventManagment.Host.Configurations;
using EventManagment.Host.Controllers;
using EventManagment.Infrastructure;
using EventManagment.Infrastructure.Common;
using EventManagment.Infrastructure.Gateway.Implementation.Caching;
using EventManagment.Infrastructure.Logging.Serilog;
using Serilog;

[assembly: ApiConventionType(typeof(FSHApiConventions))]

StaticLogger.EnsureInitialized();
Log.Information("Server Booting Up...");
try
{
    var builder = WebApplication.CreateBuilder(args);

    builder.AddConfigurations().RegisterSerilog();
    builder.Services.AddControllers();
    builder.Services.AddInfrastructure(builder.Configuration);
    builder.Services.AddApplication();
    builder.Services.AddScoped<IGatewayHandler, GatewayHandler>()
        .AddScoped<ICacheService, CacheService>();
    builder.Services.AddMemoryCache();

    var app = builder.Build();

    await app.Services.InitializeDatabasesAsync();

    app.UseInfrastructure(builder.Configuration);
    app.MapEndpoints();
    app.Run();
}
catch (Exception ex) when (!ex.GetType().Name.Equals("StopTheHostException", StringComparison.Ordinal))
{
    StaticLogger.EnsureInitialized();
    Log.Fatal(ex, "Unhandled exception");
}
finally
{
    StaticLogger.EnsureInitialized();
    Log.Information("Server Shutting down...");
    Log.CloseAndFlush();
}