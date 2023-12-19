using System.Diagnostics;

namespace MauiInsects;

public partial class AnotherPage : ContentPage {
	static int countInstances = 0;
	public AnotherPage() {
		InitializeComponent();
		countInstances++;
	}
    private async void Button_Clicked(object sender, EventArgs e) {
		//await Navigation.PopAsync();
        await Shell.Current.GoToAsync("..", true); 
    }
    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e) {
		Debug.WriteLine($"NAVIGATED: AnotherPage {countInstances} instances");

    }
	~AnotherPage() { 
		Debug.WriteLine($"FINALIZED: AnotherPage {--countInstances} instances");
	}
}