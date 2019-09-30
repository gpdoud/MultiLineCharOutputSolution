using System;
using System.Collections.Generic;
using System.Text;

namespace MultiLineCharOutput {
    
    public class AP {

        public static IList<AP> SqlQueryAp = new List<AP>() {
            new AP { PaymentMode = "C", CheckAmt = 123.45m, CheckDate = DateTime.Now },
            new AP { PaymentMode = "E", CreditMemoInd = "D", EftAmt = 678.90m, EffectiveDate = DateTime.Now, 
                PaymentCurrencyCode = "CAD", OrigAccountType = "D", RecvPartAcctType = "S",
                RcrsAccountNum = "123456789"
            },
            new AP { PaymentMode = "X" }
        };

        #warning Unverfied properties exist
        public string PaymentCurrencyCode { get; set; } = "USD";
        public string SecCode { get; set; } = "XXX"; // other: ARC, BOC, TEL
        public string OrigAccountType { get; set; } = "G"; // or D (demand deposit acct) or MCA
        public string RecvPartAcctType { get; set; } = "C"; // D, G, or S

        public string StatusInd { get; set; }
        public string Bank { get; set; }
        public string BankAccount { get; set; }
        public string AdvicePrint { get; set; }
        public string CombinePrint { get; set; }
        public string RcrsTransitRoute { get; set; }
        public string RcrsAccountNum { get; set; }
        public string CompanyCode { get; set; }
        public string CreditMemoInd { get; set; } = "C";
        public decimal DiscountAmt { get; set; }
        public string EftAdviceNum { get; set; }
        public decimal EftAmt { get; set; }
        public string CheckNumber { get; set; }
        public DateTime CheckDate { get; set; }
        public decimal CheckAmt { get; set; }
        public string EftTraceNum { get; set; }
        public string EntryDate { get; set; }
        public decimal InvoiceAmount { get; set; }
        public string InvoiceDate { get; set; }
        public decimal NetInvoiceAmt { get; set; }
        public string PayDate { get; set; }
        public string PaymentId { get; set; }
        public string PaymentMode { get; set; }
        public string SortCode { get; set; }
        public string TinType { get; set; }
        public string VendorId { get; set; }
        public string VendorName1 { get; set; }
        public string VendorType { get; set; }
        public string AccountType { get; set; }
        public string RemitAddress1 { get; set; }
        public string RemitAddress2 { get; set; }
        public string RemitAddress3 { get; set; }
        public string RemiteCity { get; set; }
        public string RemiteCountryCode { get; set; }
        public string RemitState { get; set; }
        public string RemitZipcode { get; set; }
        public DateTime EffectiveDate { get; set; }
        public string ReferenceData { get; set; }
        public string SourceCode { get; set; }
        public string TranHdrDesc { get; set; }


    }
}
