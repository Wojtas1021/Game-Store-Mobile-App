using AppGameStore.Models;
using AppGameStore.Views;
using Xamarin.Forms;

namespace AppGameStore.ViewModels
{
    public class GamesViewModel : AItemsViewModel<Game>
    {
        public GamesViewModel()
            :base("Game")
        {
        }
        public override void GoToAddPage()
        {
            Shell.Current.GoToAsync(nameof(NewGamePage));
        }
        private async void OnAddItem(object obj)
        {
            await Shell.Current.GoToAsync(nameof(NewGamePage));
        }
    }
}