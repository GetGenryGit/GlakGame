using GlakGame.MVVM.ViewModels;

namespace GlakGame.MVVM.Views;

public partial class MenuView : ContentPage
{
	public MenuView(MenuVM vm)
	{
		InitializeComponent();

		this.BindingContext = vm;
	}
}