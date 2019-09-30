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
        public string OrigAccountType { get; set; }
        public string OrigAccountNbr { get; set; } = "2079900582725"; // Wells Fargo Acct Nbr
        public string OrigBankIdType { get; set; } = "ABA";
        public string OrigBankId { get; set; } = "053101561";
        public string RecvPartyAcctType { get; set; }
        public string RcrsAccountNum { get; set; }

        public string ToFixedTextLine() {
            var sb = new StringBuilder();

            sb.Append(this.RecordId.ToFixedString(2));
            sb.Append(this.PaymentMethod.ToFixedString(3));
            sb.Append(this.CreditDebitFlag.ToFixedString(1));
            sb.Append(this.TransactionNumber.ToFixedString(30));
            sb.Append(this.ValueDate.ToString("yyyy-MM-dd").ToFixedString(10));
            sb.Append(this.PaymentAmount.ToFixedStringRight(11, '0').ToFixedString(19));
            sb.Append(this.CurrencyCode.ToFixedString(3));
            sb.Append(this.OrigAccountType.ToFixedString(1));
            sb.Append(this.OrigAccountNbr.ToFixedString(35));
            sb.Append(this.OrigBankIdType.ToFixedString(3));
            sb.Append(this.OrigBankId.ToFixedString(11));
            sb.Append(this.RecvPartyAcctType.ToFixedString(1));
            sb.Append(this.RcrsAccountNum.ToFixedString(35));
            
            return sb.ToString();
        }

        public Payment(AP ap) {
            _transNbr++;
            this.RecordId = "PY";
            SetPropertiesBasedOnPaymentMode(ap);
            this.CreditDebitFlag = SetCreditDebitFlag(ap);
            this.TransactionNumber = SetTransactionNumber(ap);
            this.CurrencyCode = ap.PaymentCurrencyCode;
            this.OrigAccountType = ap.OrigAccountType;
            this.RecvPartyAcctType = SetRecvPartyAcctType(ap);
            this.RcrsAccountNum = SetRcrsAccountNum(ap);
        }

        protected virtual string SetRcrsAccountNum(AP ap) {
            return string.Empty;
        }

        /// <summary>
        /// Receiving Party Account Type
        /// 
        /// if "C" then "D"
        /// if "S" then "S"
        /// Otherwise "-" -- error
        /// </summary>
        /// <param name="ap"></param>
        /// <returns></returns>
        private string SetRecvPartyAcctType(AP ap) {
            switch(ap.RecvPartAcctType) {
                case "C": return "D";
                case "S": return "S";
                default: return "-";
            }
        }

        protected virtual void SetPropertiesBasedOnPaymentMode(AP ap) {
            this.PaymentMethod = PaymentMethodUnknown;
            this.PaymentAmount = 0;
            this.ValueDate = DateTime.MaxValue;
        }

        protected virtual string SetTransactionNumber(AP ap) {
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
