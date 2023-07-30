using EventManagment.Application.Common.Gateway;
using EventManagment.Application.DTOs;
using EventManagment.Infrastructure.Gateway.Implementation.Caching;
using Microsoft.Extensions.Configuration;


public class GatewayHandler : IGatewayHandler
{
    private readonly HttpClient _client;
    private readonly string _baseApiPath;
    private readonly IConfigurationSection _config;
    private readonly ICacheService _cacheService;

    public GatewayHandler(IConfiguration configuration, ICacheService cacheService)
    {
        _cacheService = cacheService;
        _client = new HttpClient();
        _config = configuration.GetSection("TajneedApi");
        _baseApiPath = _config.GetSection("Url").Value;
    }

    public async Task<IList<MemberDto>> GetMembersAsync()
    {
        //var url = $"{_baseApiPath}{"jamaats"}";
        var url = $"{_baseApiPath}{"members"}";
        var request = new HttpRequestMessage();
        request.RequestUri = new Uri(url);
        request.Method = HttpMethod.Get;
        request.Headers.Add("ApiKey", _config.GetSection("ApiKey").Value);
        return await _cacheService.GetMembersCacheAsync(_client, request);
    }
    public async Task<IList<MemberDto>> GetLajnaMembersAsync()
    {
        var url = $"{_baseApiPath}{"members"}/{"auxilliarybody"}/{"Lajna"}";
        var request = new HttpRequestMessage();
        request.RequestUri = new Uri(url);
        request.Method = HttpMethod.Get;
        request.Headers.Add("ApiKey", _config.GetSection("ApiKey").Value);
        return await _cacheService.GetMembersCacheAsync(_client, request);
    }
}
