using EventManagment.Application.DTOs;

namespace EventManagment.Infrastructure.Gateway.Implementation.Caching;
public interface ICacheService
{
    Task<IList<MemberDto>> GetMembersCacheAsync(HttpClient client, HttpRequestMessage request);
}
