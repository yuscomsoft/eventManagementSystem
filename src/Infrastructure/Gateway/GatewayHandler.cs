using System.Net;
using EventManagment.Application.Common.Gateway;
using EventManagment.Application.DTOs;
using EventManagment.Infrastructure.Gateway.Extensions;
using EventManagment.Infrastructure.Gateway.Implementation.Caching;
using Microsoft.Extensions.Configuration;


public class GatewayHandler : IGatewayHandler
{
    private readonly HttpClient _client;
    private readonly string _baseApiPath;
    private readonly string _apiKey;
    private readonly IConfigurationSection _config;
    private readonly ICacheService _cacheService;

    public GatewayHandler(IConfiguration configuration, ICacheService cacheService)
    {
        _cacheService = cacheService;
        _client = new HttpClient();
        _config = configuration.GetSection("TajneedApi");
        _baseApiPath = _config.GetSection("Url").Value;
        _apiKey = _config.GetSection("ApiKey").Value;
    }

    public async Task<IList<MemberDto>> GetMembersAsync()
    {
        var url = $"{_baseApiPath}members";
        var request = new HttpRequestMessage();
        request.RequestUri = new Uri(url);
        request.Method = HttpMethod.Get;
        request.Headers.Add("ApiKey", _apiKey);
        return await _cacheService.GetMembersCacheAsync(_client, request);
    }
    public async Task<IList<MemberDto>> GetLajnaMembersAsync()
    {
        var url = $"{_baseApiPath}{"members"}/{"auxilliarybody"}/{"Lajna"}";
        var request = new HttpRequestMessage();
        request.RequestUri = new Uri(url);
        request.Method = HttpMethod.Get;
        request.Headers.Add("ApiKey", _apiKey);
        return await _cacheService.GetMembersCacheAsync(_client, request);
    }


    public async Task<MemberDto> GetMemberAsync(string memberNo)
    {
        var url = $"{_baseApiPath}members/{memberNo}";
        var request = new HttpRequestMessage();
        request.RequestUri = new Uri(url);
        request.Method = HttpMethod.Get;
        request.Headers.Add("ApiKey", _apiKey);

        var response = await _client.SendAsync(request);
        if (response.StatusCode.Equals(HttpStatusCode.OK))
        {
            return await response.ReadContentAs<MemberDto>();
        }
        else if (response.StatusCode.Equals(HttpStatusCode.NotFound))
        {
            return null;
        }

        throw new Exception(response.StatusCode.ToString());
    }

}
