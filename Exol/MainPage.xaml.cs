using System.ComponentModel;

namespace Exol;

public partial class MainPage : ContentPage
{

	public MainPage()
	{
		InitializeComponent();
	}

	async void OnNavigateButtonClicked(object sender, EventArgs e)
	{
		//Check for internet access, since we are going to be pulling categories from firebase realtime database
		if (Connectivity.NetworkAccess != NetworkAccess.Internet)
		{
			await DisplayAlert("No Internet Connection", "Please check your internet connection and try again.", "OK");
			return;
		}

		await Navigation.PushAsync(new Category());
	}

	void OnCloseButtonClicked(object sender, EventArgs e)
	{
        Application.Current.Quit();
    }
}



