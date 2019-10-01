using System;
using System.Collections.Generic;
using System.Text;
using MultiLineCharOutput.Release;

namespace MultiLineCharOutput.Payment {

    public class CheckPayment : BasePayment {

        protected override string SetTransactionNumber(AP ap) {
            var sb = new StringBuilder();
            sb.Append(DateTime.Now.ToString("yyyyMMdd"));
            var curLen = sb.ToString().Length;
            sb.Append(_transNbr.ToFixedStringRight(30 - curLen, '0'));
            return sb.ToString();
        }
        public CheckPayment(AP ap) : base(ap) {
            this.PaymentMethod = PaymentMethodCheck;
            this.PaymentAmount = ap.CheckAmt;
            this.ValueDate = ap.CheckDate;

        }
    }
}
