using Abp.Authorization;
using Abp.Localization;
using Abp.MultiTenancy;

namespace RemDijital.EmlakTakip.Authorization
{
    public class EmlakTakipAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            context.CreatePermission(PermissionNames.Pages_Users, L("Users"));
            context.CreatePermission(PermissionNames.Pages_Roles, L("Roles"));
            context.CreatePermission(PermissionNames.Pages_EstateTypes, L("EstateTypes"));
            context.CreatePermission(PermissionNames.Pages_SaleTypes, L("SaleTypes"));
            context.CreatePermission(PermissionNames.Pages_Estates, L("Estates"));
            context.CreatePermission(PermissionNames.Pages_Tenants, L("Tenants"), multiTenancySides: MultiTenancySides.Host);
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, EmlakTakipConsts.LocalizationSourceName);
        }
    }
}
