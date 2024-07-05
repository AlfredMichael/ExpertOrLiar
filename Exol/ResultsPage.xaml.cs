namespace Exol;

public partial class ResultsPage : ContentPage
{
	public ResultsPage(int score)
	{
		InitializeComponent();

        double percentage = (score / 10.0) * 100.0;
        labelScore.Text = $"YOUR SCORE: {percentage:F0}%";


        if (percentage > 50)
        {
            resultImage.Source = "expert.png"; 
            resultHead.Text = "You are an expert!";
            resultDesc.Text = "IN YO FACE!";
        }
        else
        {
            resultImage.Source = "liar.png"; 
            resultHead.Text = "You are a liar!";
            resultDesc.Text = "You make me sick, liar. Expert? More like a big, dumb liar no one wants to hang out with. pfft";
        }

    
    }

    async void OnNavigateCollectionsButtonClicked(object sender, EventArgs e)
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