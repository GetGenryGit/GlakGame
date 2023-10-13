using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GlakGame.MVVM.Views;

namespace GlakGame.MVVM.ViewModels;

public partial class MenuVM : ObservableObject
{
    public MenuVM()
    {
        maxScore = Preferences.ContainsKey("userRecord", string.Empty)
            ? Convert.ToInt32(Preferences.Get("userRecord", string.Empty))
            : 0;
    }

    #region [ObservableProperty]

    [ObservableProperty] private int maxScore;


    #endregion

    #region [RelayCommands]

    [RelayCommand]
    private async Task startGame()
        => await Shell.Current.GoToAsync("/" + nameof(GameView));
 

    [RelayCommand]
    private async Task showDevelopers()
    {
        CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
        await Toast.Make("Разработчики: Стебаков В.Д.\nОлейник И.И. Буриев Р.И.",
                  ToastDuration.Long,
                  16)
            .Show(cancellationTokenSource.Token);
    }

    #endregion

}
