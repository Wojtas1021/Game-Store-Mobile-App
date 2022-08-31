using AppGameStore.Services;
using Xamarin.Forms;

namespace AppGameStore.ViewModels
{
    public class BaseAViewModel<T> : BaseViewModel
    {
        public IDataStore<T> DataStore => DependencyService.Get<IDataStore<T>>();
    }
}
