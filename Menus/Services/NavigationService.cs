using System.Collections.ObjectModel;
using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using FluentAvalonia.UI.Controls;
using Menus.ViewModels;
using Menus.Views;

namespace Menus.Services;

public partial class NavigationService: ObservableObject
{
    public const string INICIO_VIEW = "inicio";
    public const string TIENDA_VIEW = "tienda";
    public const string AYUDA_VIEW = "ayuda";
    
    [ObservableProperty]
    private ContentControl currentView;
    
    [ObservableProperty]
    private NavigationViewItem selectedMenuItem;
    
    [ObservableProperty]
    private ObservableCollection<NavigationViewItem> menuItems=new();

    private NavigationViewItem item1;
    private NavigationViewItem item2;
    private NavigationViewItem helpItem;
    public NavigationService()
    {
        item1 = new NavigationViewItem
        {
            Content="Inicio",
            Tag=INICIO_VIEW,
            IconSource = new SymbolIconSource{Symbol = Symbol.Home}
        };
        
        item2 = new NavigationViewItem
        {
            Content="Tienda",
            Tag=TIENDA_VIEW,
            IconSource = new SymbolIconSource{Symbol = Symbol.Shop}
        };
        
        helpItem = new NavigationViewItem
        {
            Content="Ayuda",
            Tag=AYUDA_VIEW,
            IconSource = new SymbolIconSource{Symbol = Symbol.Help}
        };
        
        MenuItems.Add(item1);
        MenuItems.Add(item2);
        MenuItems.Add(helpItem);
        
        // IR A INICIO
        NavigateTo(INICIO_VIEW);
    }
    
    partial void OnSelectedMenuItemChanged(NavigationViewItem item)
    {
        NavigateTo(item.Tag.ToString()); 
    }
    
    public void NavigateTo(string tag)
    {
        if (tag.Equals(INICIO_VIEW))
        {
            HomeView homeView = new HomeView();
            homeView.DataContext = new HomeViewModel(this);
            CurrentView = homeView;
            SelectedMenuItem = item1; // Activar botón de inicio

        }else if (tag.Equals(TIENDA_VIEW))
        {
            ShopView shopView = new ShopView();
            shopView.DataContext = new ShopViewModel(this);
            CurrentView = shopView;
            SelectedMenuItem = item2; // Activar botón
        }else if (tag.Equals(AYUDA_VIEW))
        {
            CurrentView = new HelpView
            {
                DataContext = new HelpViewModel(this)
            };
            SelectedMenuItem = helpItem;
        }
    }
}