using AppGameStore.Models;
using System;

namespace AppGameStore.ViewModels
{
    public class NewCustomerViewModel : ANewItemViewModel<Customer>
    {
        private string name;
        private string surname;
        private string phone;
        private string email;
        private string country;
        private string city;
        private string street;
        private string houseNumber;
        private string postCode;

        public NewCustomerViewModel()
            :base()
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
        public string Country
        {
            get => country;
            set => SetProperty(ref country, value);
        }
        public string City
        {
            get => city;
            set => SetProperty(ref city, value);
        }
        public string Street
        {
            get => street;
            set => SetProperty(ref street, value);
        }
        public string HouseNumber
        {
            get => houseNumber;
            set => SetProperty(ref houseNumber, value);
        }
        public string PostCode
        {
            get => postCode;
            set => SetProperty(ref postCode, value);
        }
        public override Customer SetItem()
        {
            Customer newItem = new Customer()
            {
                Name = Name,
                Surname = Surname,
                Phone = Phone,
                Email = Email,
                Country = Country,
                City = City,
                Street = Street,
                HouseNumber = HouseNumber,
                PostCode = PostCode,
            };
            return newItem;
        }
    }

}
