using Firebase.Database;
using System.Collections.ObjectModel;
using Exol.Model;
using Firebase.Database.Query;

namespace Exol;

public partial class Questions : ContentPage
{
    private string _title;

    FirebaseClient firebase;
    public ObservableCollection<QuizQuestion> Questionslist { get; set; }
    public Questions(string title)
	{
		InitializeComponent();
        _title = title;
        firebase = new FirebaseClient("https://expertorliar-default-rtdb.europe-west1.firebasedatabase.app/");
        Questionslist = new ObservableCollection<QuizQuestion>();
        BindingContext = this;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        TitleLabel.Text = _title;
        var category = _title; 
        //var questions = await firebase.Child("questions").OnceAsync<QuizQuestion>();
        var questions = await firebase.Child("questions")
           .OrderBy("category")
           .EqualTo(category)
           .OnceAsync<QuizQuestion>();

        // Clear the Questions collection before adding new data or else data will keep reappearing when the the OnAppearing method is called
        Questionslist.Clear();

        int questionNumber = 1;
        foreach (var question in questions)
        {
            // add question number to the beginning of the Text property
            question.Object.Text = $"{questionNumber}. {question.Object.Text}";


            // Two ways: Stored the index and compare them with the index of the selected answer or add the A. substring to the answer in expert or liar firebase database
            // add letters to the beginning of each option
            var optionLetters = new List<string> { "A", "B", "C", "D" };
            for (int i = 0; i < question.Object.Options.Count; i++)
            {
                question.Object.Options[i] = $"{optionLetters[i]}. {question.Object.Options[i]}";
            }


            Questionslist.Add(question.Object);
            questionNumber++;
        }

        //listQuestions.ItemsSource = Questionslist;
    }

    async void OnSubmitClicked(object sender, EventArgs e)
    {
        int score = 0;
        foreach (var question in Questionslist)
        {
            if (question.SelectedOption == question.CorrectAnswer)
            {
                score++;
            }
        }

        // if score is greater than 2 display this image, else diplay this image

        await Navigation.PushAsync(new ResultsPage(score));
    }
}