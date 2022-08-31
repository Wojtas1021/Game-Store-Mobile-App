using AppGameStore.Models;
using AppGameStore.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppGameStore.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewCustomerPage : ContentPage
    {
        public Customer Item { get; set; }
        public NewCustomerPage()
        {
            InitializeComponent();
            BindingContext = new NewCustomerViewModel();
        }
    }
}