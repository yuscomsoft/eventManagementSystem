using EventManagment.Shared.Authorization;
using Microsoft.AspNetCore.Authorization;

namespace EventManagment.Infrastructure.Auth.Permissions;

public class MustHavePermissionAttribute : AuthorizeAttribute
{
    public MustHavePermissionAttribute(string action, string resource) =>
        Policy = FSHPermission.NameFor(action, resource);
}