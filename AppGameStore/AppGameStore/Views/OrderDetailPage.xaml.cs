using AppGameStore.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppGameStore.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OrderDetailPage : ContentPage
    {
        public OrderDetailViewModel _viewModel;
        public OrderDetailPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new OrderDetailViewModel();
        }
    }
}
