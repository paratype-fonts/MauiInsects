namespace MauiInsects;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;

public class MainPageViewModel : INotifyPropertyChanged {
    public event PropertyChangedEventHandler? PropertyChanged;
    public void OnPropertyChanged([CallerMemberName] string? name = null) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

    public ObservableCollection<ItemObject> Items { get; set; } = new ();
    string first = string.Empty, last = string.Empty;
    public string FirstVisibleItemIndex { get => first; set { first = value; OnPropertyChanged();} }
    public string LastVisibleItemIndex  { get => last;  set { last  = value; OnPropertyChanged();} }
    public Command OnNavigateCommand { get; set; }
    public MainPageViewModel() {
        OnNavigateCommand = new Command(async () => { 
            //if (page != null) await page.Navigation.PushAsync(new AnotherPage(), true);
            await Shell.Current.GoToAsync(nameof(AnotherPage), true); 
        });
        for (int i = 0; i < 1000; i++) {
            Items.Add(new ItemObject() { Name = "Cell", Id = i.ToString() });
        }
    }
    public void SetFirstLastVisible(int firstVisibleItemIndex, int lastVisibleItemIndex) { 
        FirstVisibleItemIndex = firstVisibleItemIndex.ToString();
        LastVisibleItemIndex  = lastVisibleItemIndex.ToString();
    }

}

public class ItemObject { 
    public string Name { get; set; } = string.Empty;
    public string Id   { get; set; } = string.Empty;
}