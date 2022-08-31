using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using WcfGameStore.Model.Entities;
using WcfGameStore.Utils;

namespace WcfGameStore.ViewModel
{
    [DataContract]
    public class OrderForView
    {
        [DataMember]
        public int OrderID { get; set; }
        [DataMember]
        public string OrderNumber { get; set; }
        [DataMember]
        public DateTime? OrderDate { get; set; }
        [DataMember]
        public int? EmployeeID { get; set; }
        [DataMember]
        public int? CustomerID { get; set; }
        [DataMember]
        public int? PaymentMethodID { get; set; }
        [DataMember]
        public DateTime? ModifiedDate { get; set; }
        public bool IsActive { get; set; }
        [DataMember]
        public virtual List<OrderDetailForView> OrderDetail { get; set; }

        public static explicit operator Order(OrderForView order)
        {
            var res = new Order();
            res.AutomatedCopyingConstructor(order);
            res.EmployeeID = order.EmployeeID;
            res.CustomerID = order.CustomerID;
            res.PaymentMethodID = order.PaymentMethodID;
            res.ModifiedDate = order.ModifiedDate;
            res.OrderDetail = order?.OrderDetail?
                .Select(a => (OrderDetail)a)
                .ToList();
            return res;
        }
        public OrderForView()
        {
        }
        public OrderForView(Order order)
        {
            this.AutomatedCopyingConstructor(order);
            EmployeeID = order.EmployeeID;
            CustomerID = order.CustomerID;
            PaymentMethodID = order.PaymentMethodID;
            ModifiedDate = order.ModifiedDate;
            OrderDetail = order.OrderDetail
                .Select(a => new OrderDetailForView(a))
                .ToList();
        }
    }
}