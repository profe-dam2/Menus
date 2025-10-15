using CommunityToolkit.Mvvm.Input;
using Menus.Services;

namespace Menus.ViewModels;


public partial class HomeViewModel:ViewModelBase
{
    private NavigationService navigationService;
    public HomeViewModel(NavigationService navigationService)
    {
        this.navigationService = navigationService;
    }

    public HomeViewModel()
    {
        
    }

    [RelayCommand]
    public void NavigateShop()
    {
        navigationService.NavigateTo(NavigationService.TIENDA_VIEW);
    }
        
}
