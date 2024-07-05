using Exol.ViewModel;
using System.Collections.ObjectModel;
using Exol.Model;
using Firebase.Database;
using Exol.Helpers;

namespace Exol;

public partial class Category : ContentPage
{
    FirebaseHelper firebaseHelper = new FirebaseHelper();


    protected async override void OnAppearing()
    {
        base.OnAppearing();
        var allcategories = await firebaseHelper.GetAllCategories();
        CategoriesCollectionView.ItemsSource = allcategories;




    }
    public Category()
	{
		InitializeComponent();

        // Set up the event handler for handling item clicks
        CategoriesCollectionView.SelectionChanged += CategoriesCollectionView_SelectionChanged;

        // Disable selection highlighting
        CategoriesCollectionView.SelectionMode = SelectionMode.Single;

    }
    private async void CategoriesCollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        // Get the clicked item
        var clickedItem = (Cat)e.CurrentSelection.FirstOrDefault();

        // Navigate to the next page and pass the clicked item's text to it
        await Navigation.PushAsync(new Questions(clickedItem.Title));
    }
    








   
 
}

/* <Grid Padding="16"
          RowDefinitions="Auto,*">

        <Label Text="Select one of the categories below, to start the quiz now"
               FontFamily="GothamRegular"
               FontSize="18"
               TextColor="{AppThemeBinding Light={StaticResource Black}, Dark={StaticResource White}}"/>


        <CollectionView Grid.Row="1"
                        Margin="0,16">

            <CollectionView.ItemsLayout>
                <LinearItemsLayout Orientation="Vertical"
                                   ItemSpacing="20"/>
            </CollectionView.ItemsLayout>

            <CollectionView.ItemTemplate>
                <DataTemplate>
                    <Border MinimumHeightRequest="315"
                            Stroke="{AppThemeBinding Light={StaticResource newcolorr}, Dark={StaticResource DarkGrey}}">
                        <Grid ColumnDefinitions="*,2*">
                            
                            <Image Source="firstcontact.png"
                                   Aspect="AspectFill"/>

                            <Grid Grid.Column="1" 
                                  Padding="16"
                                  RowDefinitions="Auto,*">

                                <!-- Title-->
                                <Label Text="cooking"
                                       FontSize="24"
                                       FontFamily="GothamBold"
                                       TextColor="{AppThemeBinding Light={StaticResource Black}, Dark={StaticResource White}}"/>
                                
                               
                                <!-- Description-->
                                <Label Text="You're claiming to be an expert on cooking; well, we've got ten cuisine-related questions for you. Answer sixty percent correctly and you're an expert! But get less than sixty percent right and the world will know you're a big fat liar!"
                                       Grid.Row="1"
                                       Padding="0,8,0,0"
                                       FontSize="16"
                                       FontFamily="GothamRegular"
                                       TextColor="{AppThemeBinding Light={StaticResource GreySmoke}, Dark={StaticResource WhiteSmoke}}"/>
                                
                            </Grid>
                        </Grid>
                    </Border>
                </DataTemplate>
            </CollectionView.ItemTemplate>

        </CollectionView>
    </Grid>*/