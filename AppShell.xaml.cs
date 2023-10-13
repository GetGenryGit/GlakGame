using CommunityToolkit.Maui.Core.Platform;
using GlakGame.MVVM.Views;

namespace GlakGame;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

        Routing.RegisterRoute(nameof(GameView),
                typeof(GameView));
    }
}
