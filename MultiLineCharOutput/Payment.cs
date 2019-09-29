using System;
using System.Collections.Generic;
using System.Text;
using MultiLineCharOutput.Release;

namespace MultiLineCharOutput {

    public class Payment : IFixedTextLine {
        private static int _nextTransNbr = 1;

        public const string PaymentMethodCheck = "CHK";
        public const string PaymentMethodEft = "DAC";
        public const string PaymentMethodUnknown = "---";

        public string RecordId { get; }
        public string PaymentMethod { get; set; }
        public string CreditDebitFlag { get; set; }
        public string TransactionNumber { get; set; }
        public DateTime ValueDate { get; set; }
        public Decimal PaymentAmount { get; set; }

        public string ToFixedTextLine() {
            var sb = new StringBuilder();

            sb.Append(this.RecordId.ToFixedString(2));
            sb.Append(this.PaymentMethod.ToFixedString(3));
            sb.Append(this.CreditDebitFlag.ToFixedString(1));
            sb.Append(this.TransactionNumber.ToFixedString(30));
            sb.Append(this.ValueDate.ToString("yyyy-MM-dd").ToFixedString(10));
            sb.Append(this.PaymentAmount.ToFixedStringRight(11, '0').ToFixedString(19));
            
            return sb.ToString();
        }

        public Payment(AP ap) {
            this.RecordId = "PY";
            SetPropertiesBasedOnPaymentMode(ap);
            this.CreditDebitFlag = SetDebitCreditFlag("XXX");
            this.TransactionNumber = SetTransactionNumber(this.PaymentMethod);
        }

        private void SetPropertiesBasedOnPaymentMode(AP ap) {
            switch(ap.PaymentMode) {
                case "C":
                    this.PaymentMethod = PaymentMethodCheck;
                    this.PaymentAmount = ap.CheckAmt;
                    this.ValueDate = ap.CheckDate;
                    break;
                case "E":
                    this.PaymentMethod = PaymentMethodEft;
                    this.PaymentAmount = ap.EftAmt;
                    this.ValueDate = ap.EffectiveDate;
                    break;
                default:
                    this.PaymentMethod = PaymentMethodUnknown;
                    this.PaymentAmount = 0;
                    this.ValueDate = DateTime.MaxValue;
                    break;
            }
        }

        private string SetTransactionNumber(string PaymentMethod) {
            var sb = new StringBuilder();
            sb.Append(DateTime.Now.ToString("yyyyMMdd"));
            var curLen = sb.ToString().Length;
            var serialNbr = string.Empty;
            if(PaymentMethod == PaymentMethodCheck) { // it is a check
                serialNbr = _nextTransNbr++.ToFixedStringRight(30, '0');
            } else { // it is a eft
                serialNbr = _nextTransNbr++.ToFixedStringRight(15-curLen, '0').ToFixedString(30);
            }
            sb.Append(serialNbr);
            return sb.ToString();
        }

        private string SetDebitCreditFlag(string SecCode) {
            var dbFlag = "C"; // the default
            var secCodes = "ARC,BOC,TEL";
            if(secCodes.Contains(SecCode)) {
                dbFlag = "D";
            }
            return dbFlag;
        }
    }
}
