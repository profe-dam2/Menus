using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Menus.Services;

namespace Menus.ViewModels;


public partial class HomeViewModel:ViewModelBase
{
    private NavigationService navigationService;
    [ObservableProperty] private bool isHelpDialogOpen;
    [ObservableProperty] private bool isExitDialgoOpen;
    public HomeViewModel(NavigationService navigationService)
    {
        this.navigationService = navigationService;
    }

    public HomeViewModel()
    {
        
    }
    
    [RelayCommand]
    public void OpenHelpDialog()
    {
        IsHelpDialogOpen = !IsHelpDialogOpen;
    }

    [RelayCommand]
    public void OpenExitDialg()
    {
        IsExitDialgoOpen = true;
    }
    
    [RelayCommand]
    public void CloseExitDialg()
    {
        IsExitDialgoOpen = false;
    }

    [RelayCommand]
    public void NavigateShop()
    {
        navigationService.NavigateTo(NavigationService.TIENDA_VIEW);
    }
        
}
