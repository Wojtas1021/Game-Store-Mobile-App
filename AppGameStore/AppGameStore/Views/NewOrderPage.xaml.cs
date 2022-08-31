using AppGameStore.Models;
using AppGameStore.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppGameStore.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewOrderPage : ContentPage
    {
        public Order Item { get; set; }
        public NewOrderPage()
        {
            InitializeComponent();
            BindingContext = new NewOrderViewModel();

        }
    }
}