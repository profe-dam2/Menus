using System.Collections.ObjectModel;
using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using Menus.ViewModels;
using Menus.Views;

namespace Menus.Services;

public partial class NavigationService: ObservableObject
{
    [ObservableProperty]
    private ContentControl currentView;
    
    public void NavigateTo(string tag)
    {
        if (tag.Equals("inicio"))
        {
            HomeView homeView = new HomeView();
            homeView.DataContext = new HomeViewModel(this);
            CurrentView = homeView;
        }else if (tag.Equals("tienda"))
        {
            ShopView shopView = new ShopView();
            shopView.DataContext = new ShopViewModel();
            CurrentView = shopView;
        }
    }
}