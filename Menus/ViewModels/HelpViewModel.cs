using System;
using System.Collections.ObjectModel;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using HarfBuzzSharp;
using Menus.Models;
using Menus.Services;

namespace Menus.ViewModels;

public partial class HelpViewModel:ViewModelBase
{
    private NavigationService navigationService;

    [ObservableProperty] private int pageIndex=0;
    [ObservableProperty] private bool isReverse = false;

    [ObservableProperty] private ObservableCollection<LanguageModel> selectedLanguages = new();
    //Lista de lenguajes
    [ObservableProperty] private ObservableCollection<LanguageModel> languageList = new();
    
    public HelpViewModel(NavigationService navigationService)
    {
        this.navigationService = navigationService;
        LoadLanguageList();
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

    private void LoadLanguageList()
    {
        var uri = new Uri("avares://Menus/Assets/Languages/python.png");
        
        LanguageList.Add(new LanguageModel(){ImagePath = new Bitmap(AssetLoader.Open(uri)), Name = "Python"});
        
        uri = new Uri("avares://Menus/Assets/Languages/c.png");
        LanguageList.Add(new LanguageModel(){ImagePath = new Bitmap(AssetLoader.Open(uri)), Name = "C"});
        
        uri = new Uri("avares://Menus/Assets/Languages/cobol.png");
        LanguageList.Add(new LanguageModel(){ImagePath = new Bitmap(AssetLoader.Open(uri)), Name = "Cobol"});
        
        uri = new Uri("avares://Menus/Assets/Languages/cplusplus.png");
        LanguageList.Add(new LanguageModel(){ImagePath = new Bitmap(AssetLoader.Open(uri)), Name = "C++"});
        
        uri = new Uri("avares://Menus/Assets/Languages/csharp.png");
        LanguageList.Add(new LanguageModel(){ImagePath = new Bitmap(AssetLoader.Open(uri)), Name = "C#"});
        
        uri = new Uri("avares://Menus/Assets/Languages/java.png");
        LanguageList.Add(new LanguageModel(){ImagePath = new Bitmap(AssetLoader.Open(uri)), Name = "JAVA"});
        
        uri = new Uri("avares://Menus/Assets/Languages/javascript.png");
        LanguageList.Add(new LanguageModel(){ImagePath = new Bitmap(AssetLoader.Open(uri)), Name = "JAVASCRIPT"});
        
        uri = new Uri("avares://Menus/Assets/Languages/kotlin.jpg");
        LanguageList.Add(new LanguageModel(){ImagePath = new Bitmap(AssetLoader.Open(uri)), Name = "KOTLIN"});
        
        uri = new Uri("avares://Menus/Assets/Languages/sql.png");
        LanguageList.Add(new LanguageModel(){ImagePath = new Bitmap(AssetLoader.Open(uri)), Name = "SQL"});

        


    }
}