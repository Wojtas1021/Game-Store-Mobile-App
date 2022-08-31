using AppGameStore.Views;
using System;
using Xamarin.Forms;

namespace AppGameStore
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(GameDetailPage), typeof(GameDetailPage));
            Routing.RegisterRoute(nameof(NewGamePage), typeof(NewGamePage));
            Routing.RegisterRoute(nameof(NewCustomerPage), typeof(NewCustomerPage));
            Routing.RegisterRoute(nameof(NewCategoryPage), typeof(NewCategoryPage));
            Routing.RegisterRoute(nameof(NewEmployeePage), typeof(NewEmployeePage));
            Routing.RegisterRoute(nameof(NewOrderPage), typeof(NewOrderPage));

        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
