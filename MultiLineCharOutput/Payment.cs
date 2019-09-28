using System;
using System.Collections.Generic;
using System.Text;

namespace MultiLineCharOutput {

    public class Payment : IFixedTextLine {
        private static int _nextTransNbr = 1;

        public const string PaymentMethodCheck = "CHK";
        public const string PaymentMethodEft = "DAC";
        public const string PaymentMethodUnknown = "???";

        public string RecordId { get; }
        public string PaymentMethod { get; set; }
        public string CreditDebitFlag { get; set; }
        public string TransactionNumber { get; set; }
        public DateTime ValueDate { get; set; }

        public string ToFixedTextLine() {
            var sb = new StringBuilder();

            sb.Append(this.RecordId.ToFixedString(2));
            sb.Append(this.PaymentMethod.ToFixedString(3));
            sb.Append(this.CreditDebitFlag.ToFixedString(1));
            sb.Append(this.TransactionNumber.ToFixedString(30));
            sb.Append(this.ValueDate.ToString("yyyy-MM-dd").ToFixedString(10));
            
            return sb.ToString();
        }

        public Payment(string PaymentMode) {
            this.RecordId = "PY";
            switch(PaymentMode) {
                case "C": this.PaymentMethod = PaymentMethodCheck; break;
                case "E": this.PaymentMethod = PaymentMethodEft; break;
                default: this.PaymentMethod = PaymentMethodUnknown; break;
            }
            this.CreditDebitFlag = SetDebitCreditFlag("???");
            this.TransactionNumber = SetTransactionNumber(this.PaymentMethod);
            this.ValueDate = DateTime.Now;
        }

        private string SetTransactionNumber(string PaymentMethod) {
            var sb = new StringBuilder();
            sb.Append(DateTime.Now.ToString("yyyyMMdd"));
            var curLen = sb.ToString().Length;
            var maxLen = PaymentMethod == PaymentMethodCheck ? 30 : 15;
            var serialNbr = _nextTransNbr++.ToFixedStringRight(maxLen - curLen, '0');
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
