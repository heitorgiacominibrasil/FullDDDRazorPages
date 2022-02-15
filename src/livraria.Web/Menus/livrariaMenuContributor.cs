﻿using System.Threading.Tasks;
using livraria.Localization;
using livraria.MultiTenancy;
using livraria.Permissions;
using Volo.Abp.Identity.Web.Navigation;
using Volo.Abp.SettingManagement.Web.Navigation;
using Volo.Abp.TenantManagement.Web.Navigation;
using Volo.Abp.UI.Navigation;

namespace livraria.Web.Menus;

public class livrariaMenuContributor : IMenuContributor
{
    public async Task ConfigureMenuAsync(MenuConfigurationContext context)
    {
        if (context.Menu.Name == StandardMenus.Main)
        {
            await ConfigureMainMenuAsync(context);
        }
    }

    private async Task ConfigureMainMenuAsync(MenuConfigurationContext context)
    {
        //var administration = context.Menu.GetAdministration();
        //var l = context.GetLocalizer<livrariaResource>();

        //context.Menu.Items.Insert(
        //    0,
        //    new ApplicationMenuItem(
        //        livrariaMenus.Home,
        //        l["Menu:Home"],
        //        "~/",
        //        icon: "fas fa-home",
        //        order: 0
        //    )
        //);

        //var bookStoreMenu = new ApplicationMenuItem(
        //   "BooksStore",
        //   l["Menu:BookStore"],
        //   icon: "fa fa-book"
        //);

        //context.Menu.AddItem(bookStoreMenu);

        ////CHECK the PERMISSION
        //if (await context.IsGrantedAsync(livrariaPermissions.Books.Default))
        //{
        //    bookStoreMenu.AddItem(new ApplicationMenuItem(
        //        "BooksStore.Books",
        //        l["Menu:Books"],
        //        url: "/Books"
        //    ));
        //}


        //if (MultiTenancyConsts.IsEnabled)
        //{
        //    administration.SetSubItemOrder(TenantManagementMenuNames.GroupName, 1);
        //}
        //else
        //{
        //    administration.TryRemoveMenuItem(TenantManagementMenuNames.GroupName);
        //}

        //administration.SetSubItemOrder(IdentityMenuNames.GroupName, 2);
        //administration.SetSubItemOrder(SettingManagementMenuNames.GroupName, 3);
        ////###############
        //###############


        if (!MultiTenancyConsts.IsEnabled)
        {
            var administration = context.Menu.GetAdministration();
            administration.TryRemoveMenuItem(TenantManagementMenuNames.GroupName);
        }

        var l = context.GetLocalizer<livrariaResource>();

        context.Menu.Items.Insert(0, new ApplicationMenuItem("BookStore.Home", l["Menu:Home"], "~/"));

        var bookStoreMenu = new ApplicationMenuItem(
            "BooksStore",
            l["Menu:BookStore"],
            icon: "fa fa-book"
        );

        context.Menu.AddItem(bookStoreMenu);

        //CHECK the PERMISSION
        if (await context.IsGrantedAsync(livrariaPermissions.Books.Default))
        {
            bookStoreMenu.AddItem(new ApplicationMenuItem(
                "BooksStore.Books",
                l["Menu:Books"],
                url: "/Books"
            ));
        }
    }
}


 