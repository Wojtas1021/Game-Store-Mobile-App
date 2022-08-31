using AppGameStore.Models;
using System;

namespace AppGameStore.ViewModels
{
    public class NewEmployeeViewModel : ANewItemViewModel<Employee>
    {
        private string name;
        private string surname;
        private string phone;
        private string email;
        private string password;
        private string login;
        private string department;

        public NewEmployeeViewModel()
            : base()
        {
        }
        public override bool ValidateSave()
        {
            return !String.IsNullOrWhiteSpace(Surname)
                && !String.IsNullOrWhiteSpace(Name);
        }
        public string Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }
        public string Surname
        {
            get => surname;
            set => SetProperty(ref surname, value);
        }
        public string Phone
        {
            get => phone;
            set => SetProperty(ref phone, value);
        }
        public string Email
        {
            get => email;
            set => SetProperty(ref email, value);
        }
        public string Password
        {
            get => password;
            set => SetProperty(ref password, value);
        }
        public string Login
        {
            get => login;
            set => SetProperty(ref login, value);
        }
        public string Department
        {
            get => department;
            set => SetProperty(ref department, value);
        }
        public override Employee SetItem()
        {
            Employee newItem = new Employee()
            {
                Name = Name,
                Surname = Surname,
                Phone = Phone,
                Email = Email,
                Password = Password,
                Login = Login,
                Department = Department,
            };
            return newItem;
        }
    }

}