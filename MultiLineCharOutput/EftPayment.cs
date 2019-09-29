using System;
using System.Collections.Generic;
using System.Text;
using MultiLineCharOutput.Release;

namespace MultiLineCharOutput {
    
    public class EftPayment : Payment {

        protected override void SetPropertiesBasedOnPaymentMode(AP ap) {
            this.PaymentMethod = PaymentMethodEft;
            this.PaymentAmount = ap.EftAmt;
            this.ValueDate = ap.EffectiveDate;
        }
        protected override string SetTransactionNumber(string PaymentMethod) {
            var sb = new StringBuilder();
            sb.Append(DateTime.Now.ToString("yyyyMMdd"));
            var curLen = sb.ToString().Length;
            sb.Append(_transNbr.ToFixedStringRight(15 - curLen, '0'));
            return sb.ToString().ToFixedString(30);
        }
        protected override string SetCreditDebitFlag(AP ap) {
            var dbFlag = base.SetCreditDebitFlag(ap);
            const string secCodes = "ARC,BOC,TEL";
            if(secCodes.Contains(ap.SecCode)) {
                dbFlag = "D";
            }
            return dbFlag;
        }
        public EftPayment(AP ap) : base(ap) {
            
        }
    }
}
