using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using FluentAvalonia.UI.Controls;
using Menus.Services;
using Menus.Views;

namespace Menus.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    [ObservableProperty]
    private ObservableCollection<NavigationViewItem> menuItems=new();

    [ObservableProperty]
    private NavigationService navigationService = new();
    
    [ObservableProperty]
    private NavigationViewItem selectedMenuItem;
    
    public MainViewModel()
    {
        NavigationViewItem item1 = new NavigationViewItem
        {
            Content="Inicio",
            Tag="inicio",
            IconSource = new SymbolIconSource{Symbol = Symbol.Home}
        };
        
        NavigationViewItem item2 = new NavigationViewItem
        {
            Content="Tienda",
            Tag="tienda",
            IconSource = new SymbolIconSource{Symbol = Symbol.Shop}
        };
        
        MenuItems.Add(item1);
        MenuItems.Add(item2);
        
        NavigationService.CurrentView = new HomeView();
        SelectedMenuItem = item1;
    }// final constructor
    
    // TODOS LOS COMANDOS Y METODOS
    partial void OnSelectedMenuItemChanged(NavigationViewItem item)
    {
       NavigationService.NavigateTo(item.Tag.ToString()); 
    }
    
    
}// final de clase