using CommunityToolkit.Maui;
using GlakGame.MVVM.ViewModels;
using GlakGame.MVVM.Views;

namespace GlakGame;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
            .UseMauiCommunityToolkit()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});


		builder.Services.AddTransient<MenuView>();
        builder.Services.AddTransient<MenuVM>();

        builder.Services.AddTransient<GameView>();
        builder.Services.AddTransient<GameVM>();


        return builder.Build();
	}
}
