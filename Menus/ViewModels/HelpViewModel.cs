using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Avalonia.Collections;
using Avalonia.Controls;
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

    [ObservableProperty] ObservableCollection<string> provincias =new();
    [ObservableProperty] ObservableCollection<string> municipios =new();
    [ObservableProperty] private string selectedProvincia;
    
    [ObservableProperty] private bool isLanguageSelected;
    
    [ObservableProperty] private int pageIndex=0;
    [ObservableProperty] private bool isReverse = false;
    
    //mostrar información para la seleccionb de lenguajes
    [ObservableProperty] private string info=string.Empty;
    
    [ObservableProperty] private ObservableCollection<LanguageModel> idsList = new();
    //Lista de lenguajes
    [ObservableProperty] private ObservableCollection<LanguageModel> languageList = new();
    //[ObservableProperty] private ObservableCollection<LanguageModel> selectedLanguages = new();
    
    [ObservableProperty] private RegisterModel registerModel = new();
    
    public HelpViewModel(NavigationService navigationService)
    {
        this.navigationService = navigationService;
        LoadLanguageList();
        LoadIDSList();
        _ = ObtenerProvincias();
        
    }

    public HelpViewModel()
    { }

    partial void OnSelectedProvinciaChanged(string value)
    {
        _ = ObtenerMunicipios(value);
    }
    
    
    private async Task ObtenerMunicipios(string provincia)
    {
        Municipios = new();
        string url =
            $"https://public.opendatasoft.com/api/records/1.0/search/?dataset=georef-spain-municipio&refine.prov_name={Uri.EscapeDataString(provincia)}&fields=mun_name,prov_name&rows=1000&sort=mun_name&format=json";
        using HttpClient client = new();
        string json = await client.GetStringAsync(url);
        using JsonDocument jsonDocument = JsonDocument.Parse(json);
        foreach (var record in 
                 jsonDocument.RootElement.GetProperty("records").EnumerateArray())
        {
            var fields = record.GetProperty("fields");
            var municipio = fields.GetProperty("mun_name");
            Municipios.Add(municipio.ToString());
        }
        
    }

    private async Task ObtenerProvincias()
    {
        string url = "https://public.opendatasoft.com/api/records/1.0/search/?dataset=georef-spain-provincia&rows=60&fields=prov_name,prov_code,acom_name&sort=prov_name&format=json";
        using HttpClient client = new();
        string json = await client.GetStringAsync(url);
        using JsonDocument jsonDocument = JsonDocument.Parse(json);

        foreach (var record in 
                 jsonDocument.RootElement.GetProperty("records").EnumerateArray())
        {
            var fields = record.GetProperty("fields");
            var provincia = fields.GetProperty("prov_name");
            Provincias.Add(provincia.ToString());
        }
    }

    [RelayCommand]
    public void SelectedLanguagesChanged(LanguageModel elementoSeleccionado)
    {
        if (RegisterModel.SelectedLanguages.Count == 0)
        {
            IsLanguageSelected =  false;
        }
        else
        {
            IsLanguageSelected =  true;
        }
        
        if (RegisterModel.SelectedLanguages.Count == 5)
        {
            //SelectedLanguages.Remove(elementoSeleccionado);
            RegisterModel.SelectedLanguages.Remove(RegisterModel.SelectedLanguages.Last());
            return;
        }
        
        Info = "HAS SELECCIONADO: " + RegisterModel.SelectedLanguages.Count + "/4";
    }
    

    [RelayCommand]
    public void IrAUsuarios()
    {
        PageIndex = 1;
        IsReverse =  false;
    }
    
    [RelayCommand]
    public void CambiarTab(string pageIndex)
    {
        if (pageIndex.Equals("1"))
        {
            PageIndex ++;
            IsReverse =  false;
        }
        else
        {
            PageIndex--;
            IsReverse =  true;
        }
    }
    

    [RelayCommand]
    public void NavigateTo(string tag_view)
    {
        navigationService.NavigateTo(tag_view);
    }

    private void LoadIDSList()
    {
        LoadItems("avares://Menus/Assets/Languages/eclipse.png",
            "Eclipse",
            IdsList);
        
        LoadItems("avares://Menus/Assets/Languages/intelli.png","IDEA Intellij",
            IdsList);
        
        LoadItems("avares://Menus/Assets/Languages/pycharm.png","Pycharm",
            IdsList);
        
        LoadItems("avares://Menus/Assets/Languages/rider.png","Rider",
            IdsList);
        LoadItems("avares://Menus/Assets/Languages/vim.png","Vim",
            IdsList);
        
        LoadItems("avares://Menus/Assets/Languages/vscode.png","Visual Studio Code",
            IdsList);
        LoadItems("avares://Menus/Assets/Languages/vscomunity.png","Visual Studio Community",
            IdsList);
        
    }

    private void LoadItems(string urlPath, string name, 
        ObservableCollection<LanguageModel> list)
    {
        list.Add(new LanguageModel(){ImagePath = 
            new Bitmap(AssetLoader.Open(new Uri(urlPath))), Name = name  });
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