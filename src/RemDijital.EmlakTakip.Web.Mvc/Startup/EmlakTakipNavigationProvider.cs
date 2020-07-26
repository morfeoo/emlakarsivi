using Abp.Application.Navigation;
using Abp.Authorization;
using Abp.Localization;
using RemDijital.EmlakTakip.Authorization;

namespace RemDijital.EmlakTakip.Web.Startup
{
    /// <summary>
    /// This class defines menus for the application.
    /// </summary>
    public class EmlakTakipNavigationProvider : NavigationProvider
    {
        public override void SetNavigation(INavigationProviderContext context)
        {
            context.Manager.MainMenu
                .AddItem(
                    new MenuItemDefinition(
                        PageNames.Home,
                        L("HomePage"),
                        url: "",
                        icon: "fas fa-home",
                        requiresAuthentication: true
                    )
                ).AddItem(
                    new MenuItemDefinition(
                        PageNames.Tenants,
                        L("Tenants"),
                        url: "Tenants",
                        icon: "fas fa-building",
                        permissionDependency: new SimplePermissionDependency(PermissionNames.Pages_Tenants)
                    )
                ).AddItem(
                    new MenuItemDefinition(
                        PageNames.Users,
                        L("Users"),
                        url: "Users",
                        icon: "fas fa-users",
                        permissionDependency: new SimplePermissionDependency(PermissionNames.Pages_Users)
                    )
                ).AddItem(
                    new MenuItemDefinition(
                        PageNames.Roles,
                        L("Roles"),
                        url: "Roles",
                        icon: "fas fa-theater-masks",
                        permissionDependency: new SimplePermissionDependency(PermissionNames.Pages_Roles)
                            )
                ).AddItem(
                    new MenuItemDefinition(
                        PageNames.EstateTypes,
                        L("EstateTypes"),
                        url: "Et",
                        icon: "fas fa-cat",
                        permissionDependency: new SimplePermissionDependency(PermissionNames.Pages_EstateTypes)
                    )
                ).AddItem(
                    new MenuItemDefinition(
                        PageNames.SaleTypes,
                        L("SaleTypes"),
                        url: "SaleTypes",
                        icon: "fas fa-money",
                        permissionDependency: new SimplePermissionDependency(PermissionNames.Pages_SaleTypes)
                    )
                ).AddItem(
                    new MenuItemDefinition(
                        PageNames.Estates,
                        L("Estates"),
                        url: "Estate",
                        icon: "fas fa-building",
                        permissionDependency: new SimplePermissionDependency(PermissionNames.Pages_Estates)
                    )
                );
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, EmlakTakipConsts.LocalizationSourceName);
        }
    }
}
