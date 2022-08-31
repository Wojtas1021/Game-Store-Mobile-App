using AppGameStore.Models;
using AppGameStore.Services;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace AppGameStore.ViewModels
{
    public class NewOrderViewModel : ANewItemViewModel<Order>
    {
        public NewOrderViewModel()
            : base()
        {
            selectedCustomer = new Customer();
            orderDate = DateTime.Now.Date;
            modifiedDate = DateTime.Now.Date;
        }
        #region fields
        private DateTime? orderDate;
        private DateTime? modifiedDate;
        private Customer selectedCustomer;
        private Employee selectedEmployee;
        private string orderNumber;
        private PaymentMethod selectedPaymentMethod;
        #endregion
        #region Properties
        public List<Customer> Customers
        {
            get
            {
                return DependencyService.Get<IDataStore<Customer>>().items;
            }
        }
        public List<Employee> Employees
        {
            get
            {
                return DependencyService.Get<IDataStore<Employee>>().items;
            }
        }
        public List<PaymentMethod> PaymentMethods
        {
            get
            {
                return DependencyService.Get<IDataStore<PaymentMethod>>().items;
            }
        }
        public Customer SelectedCustomer
        {
            get => selectedCustomer;
            set => SetProperty(ref selectedCustomer, value);
        }
        public Employee SelectedEmployee
        {
            get => selectedEmployee;
            set => SetProperty(ref selectedEmployee, value);
        }
        public PaymentMethod SelectedPaymentMethod
        {
            get => selectedPaymentMethod;
            set => SetProperty(ref selectedPaymentMethod, value);
        }
        public DateTime? OrderDate
        {
            get => orderDate;
            set => SetProperty(ref orderDate, value);
        }
        public string OrderNumber
        {
            get => orderNumber;
            set => SetProperty(ref orderNumber, value);
        }
        public DateTime? ModifiedDate
        {
            get => modifiedDate;
            set => SetProperty(ref modifiedDate, value);
        }
        #endregion
        public override bool ValidateSave()
        {
            return !String.IsNullOrWhiteSpace(selectedCustomer.Name);
        }

        public override Order SetItem()
        {
            var newItem = new Order()
            {
                OrderDate = OrderDate,
                ModifiedDate = ModifiedDate,
                OrderNumber = OrderNumber,
                CustomerID = selectedCustomer.CustomerID,
                EmployeeID = selectedEmployee.EmployeeID,
                PaymentMethodID = selectedPaymentMethod.PaymentMethodID,
            };
            return newItem;
        }
    }
}