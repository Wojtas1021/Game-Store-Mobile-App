using System;
using System.Runtime.Serialization;
using WcfGameStore.Model.Entities;
using WcfGameStore.Utils;

namespace WcfGameStore.ViewModel
{
    [DataContract]
    public class OrderDetailForView
    {
        [DataMember]
        public int OrderID { get; set; }
        [DataMember]
        public int GameID { get; set; }
        [DataMember]
        public int? Quantity { get; set; }
        [DataMember]
        public decimal? NetPrice { get; set; }
        [DataMember]
        public decimal? Tax { get; set; }
        [DataMember]
        public decimal? GrossPrice { get; set; }
        [DataMember]
        public decimal? Discount { get; set; }
        [DataMember]
        public DateTime? ModifiedDate { get; set; }
        public bool IsActive { get; set; }

        public static explicit operator OrderDetail(OrderDetailForView orderDetail)
        {
            var res = new OrderDetail
            {
                Quantity = orderDetail.Quantity
            };
            res.AutomatedCopyingConstructor(orderDetail);
            return res;
        }
        public OrderDetailForView() { }
        public OrderDetailForView(OrderDetail orderDetail)
        {
            this.AutomatedCopyingConstructor(orderDetail);
            Quantity = orderDetail.Quantity;
        }
    }
}