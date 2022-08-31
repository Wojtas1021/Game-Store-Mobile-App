using AppGameStore.Models;
using AppGameStore.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppGameStore.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewGamePage : ContentPage
    {
        public Game Item { get; set; }

        public NewGamePage()
        {
            InitializeComponent();
            BindingContext = new NewGameViewModel();
        }
    }
}