using AppGameStore.Models;
using AppGameStore.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppGameStore.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewEmployeePage : ContentPage
    {
        public Employee Item { get; set; }
        public NewEmployeePage()
        {
            InitializeComponent();
            BindingContext = new NewEmployeeViewModel();
        }
    }
}