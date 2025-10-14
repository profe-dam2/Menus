using CommunityToolkit.Mvvm.Input;
using Menus.Services;

namespace Menus.ViewModels;

public partial class HelpViewModel:ViewModelBase
{
    private NavigationService navigationService;

    public HelpViewModel(NavigationService navigationService)
    {
        this.navigationService = navigationService;
    }

    [RelayCommand]
    public void NavigateTo(string tag_view)
    {
        navigationService.NavigateTo(tag_view);
    }
}