using AppGameStore.Models;
using AppGameStore.Views;
using Xamarin.Forms;

namespace AppGameStore.ViewModels
{
    public class CategoryViewModel : AItemsViewModel<Category>
    {
        public CategoryViewModel()
       : base("Category")
        {
        }
        public override void GoToAddPage()
        {
            Shell.Current.GoToAsync(nameof(NewCategoryPage));
        }
    }
}

