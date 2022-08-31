using ServiceReferenceGameStore;
using System;
using System.Collections.Generic;
using AppGameStore.Utils;
using System.Linq;

namespace AppGameStore.Models
{
    public class Order
    {
        public int OrderID { get; set; }
        public string OrderNumber { get; set; }
        public DateTime? OrderDate { get; set; }
        public int? EmployeeID { get; set; }
        public int? CustomerID { get; set; }
        public int? PaymentMethodID { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool IsActive { get; set; }
        public List<OrderDetail> OrderDetail { get; set; }

        public static explicit operator OrderForView(Order order)
        {
            var res = new OrderForView();
            res.AutomatedCopyingConstructor(order);
            res.OrderNumber = order.OrderNumber;
            res.EmployeeID = order.EmployeeID;
            res.CustomerID = order.CustomerID;
            res.PaymentMethodID = order.PaymentMethodID;
            res.ModifiedDate = order.ModifiedDate;
            res.OrderDetail = order.OrderDetail?
                .Select(a => (OrderDetailForView)a)?
                .ToList();
            return res;
        }
        public Order()
        {
        }
        public Order(OrderForView order)
        {
            this.AutomatedCopyingConstructor(order);
            OrderNumber = order.OrderNumber;
            EmployeeID = order.EmployeeID;
            CustomerID = order.CustomerID;
            PaymentMethodID = order.PaymentMethodID;
            ModifiedDate = order.ModifiedDate;
        }
    }
}
