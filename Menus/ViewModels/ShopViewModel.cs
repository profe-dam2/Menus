using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Menus.Services;
namespace Menus.ViewModels;

public partial class ShopViewModel:ViewModelBase
{
    private NavigationService navigationService;
    public ShopViewModel(NavigationService navigationService)
    {
        this.navigationService = navigationService;
    }

    [RelayCommand]
    public void NavigateToInicio()
    {
        navigationService.NavigateTo(NavigationService.INICIO_VIEW);
    }
    
}