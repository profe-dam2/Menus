using System.Collections.ObjectModel;

namespace Menus.Models;

public class RegisterModel
{
    public ObservableCollection<LanguageModel> SelectedLanguages { get; set; } = new();
    
}