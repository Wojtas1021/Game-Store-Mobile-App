using AppGameStore.Models;
using System.Linq;
using ServiceReferenceGameStore;
using System.Collections.Generic;

namespace AppGameStore.Services
{
    public class CustomerDataStore : AbstractDataStore<Customer>
    {
        public CustomerDataStore()
            :base()
        {
            GameStoreServices.GetCustomers(new GetCustomersRequest()).GetCustomersResult
             .Select(k => new Customer(k))
             .ToList();
        }
        public override void Add(Customer item)
        {
          GameStoreServices.AddOrUpdateCustomer(new AddOrUpdateCustomerRequest(new CustomerForView 
          { Name = item.Name, Surname = item.Surname, Phone = item.Phone,
            Email = item.Email, Country = item.Country, City = item.City,
            Street = item.Street, HouseNumber = item.HouseNumber, PostCode = item.PostCode
          }));
        }
        public override Customer Find(Customer customer)
        {
            return items.Where((Customer arg) => arg.CustomerID == customer.CustomerID).FirstOrDefault();
        }
        public override Customer Find(int id)
        {
            return items.Where((Customer arg) => arg.CustomerID == id).FirstOrDefault();
        }
        public override void Refresh()
        {
            List<CustomerForView> listaCFV =
                GameStoreServices.GetCustomers(new GetCustomersRequest())
                .GetCustomersResult
                .ToList();
            items = new List<Customer>();
            foreach (var k in listaCFV)
            {
                items.Add(new Customer(k));
            }
        }
    }
}

