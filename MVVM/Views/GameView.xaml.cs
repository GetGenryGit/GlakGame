using GlakGame.MVVM.ViewModels;

namespace GlakGame.MVVM.Views;

public partial class GameView : ContentPage
{
	public GameView(GameVM vm)
	{
		InitializeComponent();

		this.BindingContext = vm;
	}
}