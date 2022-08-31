using AppGameStore.Models;
using AppGameStore.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppGameStore.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewCategoryPage : ContentPage
    {
        public Category Item { get; set; }
        public NewCategoryPage()
        {
            InitializeComponent();
            BindingContext = new NewCategoryViewModel();
        }
    }
}