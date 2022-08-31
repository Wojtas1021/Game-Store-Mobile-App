using AppGameStore.Models;
using AppGameStore.Services;
using Xamarin.Forms;

namespace AppGameStore.ViewModels
{
    public class BaseGameViewModel : BaseViewModel
    {
        public IDataStore<Game> DataStore => DependencyService.Get<IDataStore<Game>>();

    }
}
