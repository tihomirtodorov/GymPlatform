using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;

namespace WebApi.Utilities.Auth
{
    public class PermissionsRequirement : IAuthorizationRequirement
    {
        public IEnumerable<string> AllowedPermissions { get; set; }

        public PermissionsRequirement(IEnumerable<string> allowedPermissions)
        {
            AllowedPermissions = allowedPermissions;
        }
    }
}
