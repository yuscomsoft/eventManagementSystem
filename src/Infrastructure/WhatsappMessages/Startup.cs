using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EventManagment.Infrastructure.WhatsappMessages;
internal static class Startup
{
    internal static IServiceCollection AddWhatsappMessages(this IServiceCollection services, IConfiguration config) =>
        services.Configure<WhatsappMessageSettings>(config.GetSection(nameof(WhatsappMessageSettings)));
}
