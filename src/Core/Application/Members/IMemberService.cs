using EventManagment.Application.DTOs;

namespace EventManagment.Application.Members;
public interface IMemberService : ITransientService
{
    //Task<PaginationResponse<MemberDetailsDto>> SearchAsync(MemberListFilter filter, CancellationToken cancellationToken);

    //Task<bool> ExistsWithNameAsync(string name);
    Task<PaginationResponse<MemberDetailsDto>> GetListAsync(PaginationFilter filter);

    //Task<int> GetCountAsync(CancellationToken cancellationToken);

    Task<MemberDetailsDto> GetByChandaNumberAsync(string chandaNumber, CancellationToken cancellationToken);

    /*Task<List<UserRoleDto>> GetRolesAsync(string userId, CancellationToken cancellationToken);
    Task<string> AssignRolesAsync(string userId, UserRolesRequest request, CancellationToken cancellationToken);

    Task<List<string>> GetPermissionsAsync(string userId, CancellationToken cancellationToken);
    Task<bool> HasPermissionAsync(string userId, string permission, CancellationToken cancellationToken = default);
    Task InvalidatePermissionCacheAsync(string userId, CancellationToken cancellationToken);*/

    //Task ToggleStatusAsync(ToggleMemberStatusRequest request, CancellationToken cancellationToken);

    // Task<string> GetOrCreateFromPrincipalAsync(ClaimsPrincipal principal);
    // Task<string> CreateAsync(CreateUserRequest request, string origin);
    //Task UpdateAsync(UpdateMemberRequest request, string userId);
}
