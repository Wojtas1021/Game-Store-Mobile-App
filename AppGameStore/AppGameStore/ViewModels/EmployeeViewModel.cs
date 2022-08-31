using AppGameStore.Models;
using AppGameStore.Views;
using Xamarin.Forms;

namespace AppGameStore.ViewModels
{
    public class EmployeeViewModel : AItemsViewModel<Employee>
    {
        public EmployeeViewModel()
            : base("Employee")
        {
        }
        public override void GoToAddPage()
        {
            Shell.Current.GoToAsync(nameof(NewEmployeePage));
        }
    }
}
