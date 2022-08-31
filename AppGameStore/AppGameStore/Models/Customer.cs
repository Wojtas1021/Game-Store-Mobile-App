using System;
using AppGameStore.Utils;
using ServiceReferenceGameStore;

namespace AppGameStore.Models
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public string PostCode { get; set; }
        public DateTime ModifiedDate { get; set; } = DateTime.Now;
        public bool IsActive { get; set; }
        public Customer() { }
        public Customer(CustomerForView customer)
        {
            PropertyUtils.AutomatedCopyingConstructor(this, customer);
        }
    }
}
