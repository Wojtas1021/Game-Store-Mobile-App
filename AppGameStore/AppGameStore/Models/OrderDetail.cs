using AppGameStore.Utils;
using ServiceReferenceGameStore;
using System;

namespace AppGameStore.Models
{
    public class OrderDetail
    {
        public int OrderID { get; set; }
        public int GameID { get; set; }
        public int? Quantity { get; set; }
        public decimal? NetPrice { get; set; }
        public decimal? Tax { get; set; }
        public decimal? GrossPrice { get; set; }
        public decimal? Discount { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool IsActive { get; set; }
       
       public static explicit operator OrderDetailForView(OrderDetail orderDetail)
        {
            var res = new OrderDetailForView
            {
                Quantity = orderDetail.Quantity
            };
            res.AutomatedCopyingConstructor(orderDetail);
            return res;
        }
        public OrderDetail() { }
        public OrderDetail(OrderDetailForView orderDetail)
        {
            this.AutomatedCopyingConstructor(orderDetail);
            Quantity = orderDetail.Quantity;
        }      
    }
}
