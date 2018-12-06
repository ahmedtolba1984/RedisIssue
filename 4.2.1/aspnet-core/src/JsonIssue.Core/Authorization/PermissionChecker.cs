using Abp.Authorization;
using JsonIssue.Authorization.Roles;
using JsonIssue.Authorization.Users;

namespace JsonIssue.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
