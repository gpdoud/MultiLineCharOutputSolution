using System;
using System.Collections.Generic;
using System.Text;

namespace MultiLineCharOutput.Payment {
    
    public class UnknownPayment : BasePayment {

        protected override string SetTransactionNumber(AP ap) {
            return 0.ToString();
        }
        public UnknownPayment(AP ap) : base(ap) {
            this.PaymentMethod = PaymentMethodUnknown;
            this.PaymentAmount = 0m;
            this.ValueDate = DateTime.MaxValue;
        }
    }
}
