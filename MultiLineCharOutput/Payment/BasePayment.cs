using System;
using System.Collections.Generic;
using System.Text;
using MultiLineCharOutput.Release;

namespace MultiLineCharOutput.Payment {

    public abstract class BasePayment : IFixedTextLine {
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
        public string RecvBankPrimaryIdType { get; set; }
        public string RecvBankPrimaryId { get; set; }
        public string EddHandlingCode { get; set; }
        public string InvManagerFlag { get; set; }
        public string MessageText { get; set; }

        private string Pad(int len) {
            return string.Empty.ToFixedString(len);
        }

        public string ToFixedTextLine() {
            var sb = new StringBuilder();

            sb.Append(this.RecordId.ToFixedString(2)); // 1-2
            sb.Append(this.PaymentMethod.ToFixedString(3)); // 3-5
            sb.Append(this.CreditDebitFlag.ToFixedString(1)); // 6
            sb.Append(this.TransactionNumber.ToFixedString(30)); // 7-36
            sb.Append(this.ValueDate.ToString("yyyy-MM-dd").ToFixedString(10)); // 37-46
            sb.Append(this.Pad(30)); // 47-56
            sb.Append(this.PaymentAmount.ToFixedStringRight(11, '0').ToFixedString(19)); // 57-75
            sb.Append(this.CurrencyCode.ToFixedString(3)); // 76-78
            sb.Append(this.OrigAccountType.ToFixedString(1)); // 79
            sb.Append(this.OrigAccountNbr.ToFixedString(35)); // 80-114
            sb.Append(this.OrigBankIdType.ToFixedString(3)); // 115-117
            sb.Append(this.OrigBankId.ToFixedString(11)); // 118-128
            sb.Append(this.RecvPartyAcctType.ToFixedString(1)); // 129
            sb.Append(this.RcrsAccountNum.ToFixedString(35)); // 130-164
            sb.Append(this.RecvBankPrimaryIdType.ToFixedString(3)); // 165-167
            sb.Append(this.RecvBankPrimaryId.ToFixedString(11)); // 168-178
            sb.Append(this.EddHandlingCode.ToFixedString(1)); // 179
            sb.Append(this.InvManagerFlag.ToFixedString(1)); // 180
            sb.Append(this.MessageText.ToFixedString(160));
            
            return sb.ToString();
        }

        public BasePayment(AP ap) {
            _transNbr++;
            this.RecordId = "PY";
            this.CreditDebitFlag = SetCreditDebitFlag(ap);
            this.TransactionNumber = SetTransactionNumber(ap);
            this.CurrencyCode = ap.PaymentCurrencyCode;
            this.OrigAccountType = ap.OrigAccountType;
            this.RecvPartyAcctType = SetRecvPartyAcctType(ap);
            this.RcrsAccountNum = SetRcrsAccountNum(ap);
            this.RecvBankPrimaryIdType = ap.RecvBankPrimaryIdType;
            this.RecvBankPrimaryId = string.Empty;
            this.EddHandlingCode = ap.PmpRemitanceInd;
            this.InvManagerFlag = ap.InvManagerFlag;
            this.MessageText = ap.MessageText;
        }

        protected abstract string SetTransactionNumber(AP ap);
        /// <summary>
        /// RcrsAccountNum
        /// Is blank unless it is an EFT payment
        /// </summary>
        /// <param name="ap"></param>
        /// <returns></returns>
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

        protected virtual string SetCreditDebitFlag(AP ap) {
            return ap.CreditMemoInd; // the default
        }
    }
}
