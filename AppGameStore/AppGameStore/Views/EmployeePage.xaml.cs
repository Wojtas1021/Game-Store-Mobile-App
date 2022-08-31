using AppGameStore.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppGameStore.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EmployeePage : ContentPage
    {
        EmployeeViewModel _viewModel;

        public EmployeePage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new EmployeeViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}