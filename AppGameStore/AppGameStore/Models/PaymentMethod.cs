using AppGameStore.Utils;
using System;

namespace AppGameStore.Models
{
    public class PaymentMethod
    {
        public int PaymentMethodID { get; set; }
        public string Name { get; set; }
        public string Notes { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool IsActive { get; set; }

        public PaymentMethod() { }
        public PaymentMethod(PaymentMethod paymentMethod)
        {
            PropertyUtils.AutomatedCopyingConstructor(this, paymentMethod);
        }
    }
}
