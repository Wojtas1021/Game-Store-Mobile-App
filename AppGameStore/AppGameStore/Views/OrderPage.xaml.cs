using AppGameStore.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppGameStore.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OrderPage : ContentPage
    {
        OrderViewModel _viewModel;

        public OrderPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new OrderViewModel();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}