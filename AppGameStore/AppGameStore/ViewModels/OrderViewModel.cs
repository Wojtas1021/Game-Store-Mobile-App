using AppGameStore.Models;
using AppGameStore.Views;
using Xamarin.Forms;

namespace AppGameStore.ViewModels
{
    public class OrderViewModel : AItemsViewModel<Order>
    {
        public OrderViewModel()
            : base("Order")
        {
        }
        public override void GoToAddPage()
        {
            Shell.Current.GoToAsync(nameof(NewOrderPage));
        }
    }
}
