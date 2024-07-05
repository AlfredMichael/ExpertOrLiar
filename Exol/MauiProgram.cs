using CommunityToolkit.Maui;
using Exol.ViewModel;
using Microsoft.Maui.Controls.Compatibility.Hosting;

namespace Exol;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .UseMauiCompatibility()
            .ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                fonts.AddFont("Gotham-Regular.ttf", "GothamRegular");
                fonts.AddFont("GothamMedium.ttf", "GothamMedium");
                fonts.AddFont("GothamBold.ttf", "GothamBold");
                fonts.AddFont("GothamBoldItalic.ttf", "GothamBoldItalic");
                fonts.AddFont("materialdesignicons-webfont.ttf", "IconFontTypes");
            });

        builder.Services.AddSingleton<IConnectivity>(Connectivity.Current);
        builder.Services.AddSingleton<MainPage>();
        builder.Services.AddSingleton<Category>();


        return builder.Build();
	}
}
