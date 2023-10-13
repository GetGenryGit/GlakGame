using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GlakGame.MVVM.Models;

namespace GlakGame.MVVM.ViewModels;

public partial class GameVM : ObservableObject
{
    private Action action;

    public GameVM()
    {
        gameRefresh();

        action = new Action(async () =>
        {
            await timerGame();
        });
        action.Invoke();
    }

    #region [ObservableProperties]

    [ObservableProperty] private int gameTimer = 60;

    [ObservableProperty] private int score;

    [ObservableProperty] private List<CardImage> cards = new();

    #endregion

    #region [RelayCommands]

    private void gameRefresh()
    {
        Cards = new List<CardImage>();

        for (int i = 0; i <= 15; i++)
        {
            Cards.Add(new CardImage());
        }

        Random rnd = new Random();

        int correctNumber = rnd.Next(0, 15);

        Cards[correctNumber] = new CardImage
        {
            ImageUrl = "win_image256x256.jpg",
            IsWinImage = true,
        };
    }

    private async Task timerGame()
    {
        while (GameTimer > 1)
        {
            await Task.Delay(1000);
            GameTimer -= 1;

            if (Shell.Current.CurrentState.Location.OriginalString != "//MenuView/GameView")
            {
                return;
            }
        }

        if (Preferences.Get("userRecord", string.Empty) == string.Empty)
        {
            await Shell.Current.DisplayAlert("Время вышло", $"У вас новый рекорд! {Score} Баллов!", "ОК");
            Preferences.Set("userRecord", Score.ToString());
        }
        else
        {
            if (Convert.ToInt32(Preferences.Get("userRecord", string.Empty)) < Score)
            {
                await Shell.Current.DisplayAlert("Время вышло", $"У вас новый рекорд! {Score} Баллов!", "ОК");
                Preferences.Set("userRecord", Score.ToString());
            }
            else
            {
                await Shell.Current.DisplayAlert("Время вышло", $"Вы не смогли побить свой рекорд! {Score} Баллов!", "ОК");
            }

        }

        App.Current.MainPage = new AppShell();
    }

    [RelayCommand]
    private async Task selectImage(CardImage item)
    {
        if (item.IsWinImage)
        {
            Score += 3;
        }
        else
        {
            if ((Score - 5) < 0)
            {
                await Shell.Current.DisplayAlert("Вы проиграли!", "было набрано отрицательно количество очков", "ОК");
                App.Current.MainPage = new AppShell();
            }
            else
            {
                Score -= 5;
            }
        }

        gameRefresh();
    }

    #endregion

}
