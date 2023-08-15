using EventManagment.Application.Common.WhatsappMessages;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace EventManagment.Infrastructure.WhatsappMessages;
public class WhatsappMessageService : IWhatsappMessage
{
    private readonly WhatsappMessageSettings _settings;
    private readonly ILogger<WhatsappMessageService> _logger;

    public WhatsappMessageService(IOptions<WhatsappMessageSettings> settings, ILogger<WhatsappMessageService> logger) =>
    (_settings, _logger) = (settings.Value, logger);

    public async Task SendAsync(WhatsappMessageRequest request, CancellationToken ct = default)
    {
        try
        {
            using var httpClient = new HttpClient();

            var content = new FormUrlEncodedContent(new[]
            {
            new KeyValuePair<string, string>("token", _settings.Token),
            new KeyValuePair<string, string>("to", request.RecipientNumber),
            new KeyValuePair<string, string>("body", request.MessageBody)
            });

            var response = await httpClient.PostAsync(_settings.ApiUrl, content);
            var output = await response.Content.ReadAsStringAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
        }
    }
}
