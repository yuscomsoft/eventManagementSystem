using EventManagment.Application.DTOs;
using EventManagment.Infrastructure.Gateway.Extensions;
using Microsoft.Extensions.Caching.Memory;

namespace EventManagment.Infrastructure.Gateway.Implementation.Caching;


public class CacheService : ICacheService
{
    private readonly IMemoryCache _memoryCache;

    public CacheService(IMemoryCache memoryCache) => _memoryCache = memoryCache;

    public async Task<IList<MemberDto>> GetMembersCacheAsync(HttpClient client, HttpRequestMessage request)
    {
        var output = _memoryCache.Get<List<MemberDto>>("Member");

        if (output is not null) return output;
        var response = await client.SendAsync(request);
        output = await response.ReadContentAs<List<MemberDto>>();
        _memoryCache.Set("Member", output, TimeSpan.FromHours(12));
        return output;
    }
}
