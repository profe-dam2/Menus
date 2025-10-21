using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Menus.Services;

namespace Menus.ViewModels;

public partial class HelpViewModel:ViewModelBase
{
    private NavigationService navigationService;

    [ObservableProperty] private int pageIndex=0;
    [ObservableProperty] private bool isReverse = false;
    public HelpViewModel(NavigationService navigationService)
    {
        this.navigationService = navigationService;
    }

    public HelpViewModel()
    {
        
    }

    [RelayCommand]
    public void IrAUsuarios()
    {
        PageIndex = 1;
        IsReverse =  false;
    }
    
    [RelayCommand]
    public void IrAtras()
    {
        PageIndex = 0;
        IsReverse =  true;
    }
    

    [RelayCommand]
    public void NavigateTo(string tag_view)
    {
        navigationService.NavigateTo(tag_view);
    }
}