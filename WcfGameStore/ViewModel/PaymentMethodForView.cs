using System;
using System.Runtime.Serialization;
using WcfGameStore.Model.Entities;
using WcfGameStore.Utils;

namespace WcfGameStore.ViewModel
{
    [DataContract]
    public class PaymentMethodForView
    {
        [DataMember]
        public int PaymentMethodID { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Notes { get; set; }
        [DataMember]
        public DateTime? ModifiedDate { get; set; }
        [DataMember]
        public bool IsActive { get; set; }

        public PaymentMethodForView() { }
        //konstruktor mapujący
        public PaymentMethodForView(PaymentMethod paymentMethod)
        {
            PropertyUtils.AutomatedCopyingConstructor(this, paymentMethod);
        }
        public static implicit operator PaymentMethod(PaymentMethodForView paymentMethod)
        {
            var res = new PaymentMethod();
            res.AutomatedCopyingConstructor(paymentMethod);
            return res;
        }

        public static implicit operator PaymentMethodForView(PaymentMethod paymentMethod)
        {
            var res = new PaymentMethodForView(paymentMethod);
            return res;
        }
    }
}