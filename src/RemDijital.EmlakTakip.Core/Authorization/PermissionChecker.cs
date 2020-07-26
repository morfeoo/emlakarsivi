using Abp.Authorization;
using RemDijital.EmlakTakip.Authorization.Roles;
using RemDijital.EmlakTakip.Authorization.Users;

namespace RemDijital.EmlakTakip.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
