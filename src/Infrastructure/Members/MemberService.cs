using EventManagment.Application.Common.Exceptions;
using EventManagment.Application.Common.Gateway;
using EventManagment.Application.Common.Models;
using EventManagment.Application.DTOs;
using EventManagment.Application.Members;
using Mapster;

namespace EventManagment.Infrastructure.Members;
public class MemberService : IMemberService
{
    private readonly IGatewayHandler _gateway;

    public MemberService(IGatewayHandler gateway)
    {
        _gateway = gateway;
    }

    public async Task<MemberDto> GetByChandaNumberAsync(string chandaNumber, CancellationToken cancellationToken = default)
    {
        var member = await _gateway.GetMemberAsync(chandaNumber);
        _ = member ?? throw new NotFoundException(string.Format("Member with Chanda Number {0} does not exist.", chandaNumber));
        return member;
    }

    public async Task<PaginationResponse<MemberDetailsDto>> GetListAsync(PaginationFilter filter)
    {
        var membersResponse = await _gateway.GetMembersAsync();
        var count = membersResponse.Count;
        var response = membersResponse.Adapt<List<MemberDetailsDto>>();
        return new PaginationResponse<MemberDetailsDto>(response, count, filter.PageNumber, filter.PageSize);
    }
}
