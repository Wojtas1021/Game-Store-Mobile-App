using AppGameStore.ViewModels;
using Xamarin.Forms;

namespace AppGameStore.Views
{
    public partial class GameDetailPage : ContentPage
    {
        public GameDetailPage()
        {
            InitializeComponent();
            BindingContext = new GameDetailViewModel();
        }
    }
}