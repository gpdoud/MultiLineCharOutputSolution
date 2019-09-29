using System;
using System.Collections.Generic;
using System.Text;
using MultiLineCharOutput.Release;

namespace MultiLineCharOutput {

    public class CheckPayment : Payment {

        protected override void SetPropertiesBasedOnPaymentMode(AP ap) {
            this.PaymentMethod = PaymentMethodCheck;
            this.PaymentAmount = ap.CheckAmt;
            this.ValueDate = ap.CheckDate;
        }
        /* 
         * SetTransactionNumber for checks uses the base class Payment because
         * most transactions will be checks. This is the override if ever needed.
         */
        //protected override string SetTransactionNumber(string PaymentMethod) {
        //    return new NotImplementedException();
        //}
        public CheckPayment(AP ap) : base(ap) {

        }
    }
}
