using System;
using System.Collections.Generic;
using System.Text;
using MultiLineCharOutput.Release;

namespace MultiLineCharOutput {

    public class Payment : IFixedTextLine {
        public static int _transNbr { get; protected set; } = 1;

        public const string PaymentMethodCheck = "CHK";
        public const string PaymentMethodEft = "DAC";
        public const string PaymentMethodUnknown = "---";

        public string RecordId { get; }
        public string PaymentMethod { get; set; }
        public string CreditDebitFlag { get; set; }
        public string TransactionNumber { get; set; }
        public DateTime ValueDate { get; set; }
        public Decimal PaymentAmount { get; set; }
        public string CurrencyCode { get; set; }

        public string ToFixedTextLine() {
            var sb = new StringBuilder();

            sb.Append(this.RecordId.ToFixedString(2));
            sb.Append(this.PaymentMethod.ToFixedString(3));
            sb.Append(this.CreditDebitFlag.ToFixedString(1));
            sb.Append(this.TransactionNumber.ToFixedString(30));
            sb.Append(this.ValueDate.ToString("yyyy-MM-dd").ToFixedString(10));
            sb.Append(this.PaymentAmount.ToFixedStringRight(11, '0').ToFixedString(19));
            sb.Append(this.CurrencyCode.ToFixedString(3));
            
            return sb.ToString();
        }

        public Payment(AP ap) {
            _transNbr++;
            this.RecordId = "PY";
            SetPropertiesBasedOnPaymentMode(ap);
            this.CreditDebitFlag = SetCreditDebitFlag(ap);
            this.TransactionNumber = SetTransactionNumber(this.PaymentMethod);
            this.CurrencyCode = ap.PaymentCurrencyCode; 
        }

        protected virtual void SetPropertiesBasedOnPaymentMode(AP ap) {
            this.PaymentMethod = PaymentMethodUnknown;
            this.PaymentAmount = 0;
            this.ValueDate = DateTime.MaxValue;
        }

        protected virtual string SetTransactionNumber(string PaymentMethod) {
            var sb = new StringBuilder();
            sb.Append(DateTime.Now.ToString("yyyyMMdd"));
            var curLen = sb.ToString().Length;
            sb.Append(_transNbr.ToFixedStringRight(30-curLen, '0'));
            return sb.ToString();
        }

        protected virtual string SetCreditDebitFlag(AP ap) {
            return ap.CreditMemoInd; // the default
        }
    }
}
