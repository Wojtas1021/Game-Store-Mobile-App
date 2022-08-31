using AppGameStore.Models;
using AppGameStore.Views;
using Xamarin.Forms;

namespace AppGameStore.ViewModels
{
    public class CustomerViewModel : AItemsViewModel<Customer>
    {
        public CustomerViewModel()
            :base("Customer")
        {
        }
        public override void GoToAddPage()
        {
            Shell.Current.GoToAsync(nameof(NewCustomerPage));
        }
    }
}
