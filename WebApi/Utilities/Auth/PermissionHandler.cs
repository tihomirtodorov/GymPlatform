using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace WebApi.Utilities.Auth
{
    public class PermissionHandler : AuthorizationHandler<PermissionsRequirement>
    {
        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissionsRequirement requirement)

        {
            var permissions = context.User.Claims.Where(x => x.Type == "permissions");

            var isAllowedToAccessResource =
                requirement.AllowedPermissions.All(x => permissions.Any(r => r.Value == x));

            if (isAllowedToAccessResource)
            {
                context.Succeed(requirement);
            }
            else
            {
                context.Fail();
            }
        }
    }
}
