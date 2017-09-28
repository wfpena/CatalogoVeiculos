using Abp.Application.Navigation;
using Abp.Localization;

namespace SimpleTaskSystem.WebSpaAngular
{
    /// <summary>
    /// This class defines menus for the application.
    /// It uses ABP's menu system.
    /// When you add menu items here, they are automatically appear in angular application.
    /// See .cshtml and .js files under App/Main/views/layout/header to know how to render menu.
    /// </summary>
    public class SimpleTaskSystemNavigationProvider : NavigationProvider
    {
        public override void SetNavigation(INavigationProviderContext context)
        {
            context.Manager.MainMenu
                .AddItem(
                    new MenuItemDefinition(
                        "Vehicles",
                        new LocalizableString("Veiculos", SimpleTaskSystemConsts.LocalizationSourceName),
                        url: "#/vehicles",
                        icon: "fa fa-car"
                        )
                );
        }
    }
}
