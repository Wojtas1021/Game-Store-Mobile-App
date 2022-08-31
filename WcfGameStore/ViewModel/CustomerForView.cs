using System;
using System.Runtime.Serialization;
using WcfGameStore.Model.Entities;
using WcfGameStore.Utils;

namespace WcfGameStore.ViewModel
{
    // typ danych używanych za zewnątrz
    [DataContract]
    public class CustomerForView
    {
        //atrybut pokazujący, że property bedzię widoczny na zewnątrz
        [DataMember]
        public int CustomerID { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Surname { get; set; }
        [DataMember]
        public string Phone { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string Country { get; set; }
        [DataMember]
        public string City { get; set; }
        [DataMember]
        public string Street { get; set; }
        [DataMember]
        public string HouseNumber { get; set; }
        [DataMember]
        public string PostCode { get; set; }
        [DataMember]
        public DateTime ModifiedDate { get; set; } = DateTime.Now;
        public bool IsActive { get; set; }

        public CustomerForView(Customer customer)
        {
            PropertyUtils.AutomatedCopyingConstructor(this, customer);
        }
        public static implicit operator Customer(CustomerForView customer)
        {
            var res = new Customer();
            res.AutomatedCopyingConstructor(customer);
            return res;
        }

        public static implicit operator CustomerForView(Customer customer)
        {
            var res = new CustomerForView(customer);
            return res;
        }
        public Customer ConvertToCustomer()
        {
            var res = new Customer();
            res.AutomatedCopyingConstructor(this);
            res.IsActive = true;
            return res;
        }
    }
}