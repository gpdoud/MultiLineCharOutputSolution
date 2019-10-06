using System;
using System.Collections.Generic;
using System.Text;

namespace MultiLineCharOutput {

    public class AP {

        public static IList<AP> SqlQueryAp = new List<AP>() {
            new AP {
                Id = 1,
                StatusInd = "D",
                Bank = "Ken's Bank",
                BankAcctNbr = "1111111111111",
                BankAcctTransit = "11111111",
                RcrsTransitRoute = "",
                RcrsAccountNum = "",
                CompanyCode = "KEN",
                DiscountAmt = 0,
                EftAdviceNum = "",
                EftAmt = 0,
                CheckNumber = "1000000000",
                CheckDate = "5/11/1991",
                CheckAmt = 100,
                EftTraceNum = "",
                EntryDate = "5/1/1991",
                InvoiceAmt = 100,
                InvoiceDate = "10/1/2019",
                NetInvoiceAmt = 100,
                PayDate = "10/1/2019",
                PaymentId = "1111111",
                PaymentMode = "C",
                TinType = "C",
                VendorId = "AG111111",
                VendorName1 = "KEN DOUD",
                GenericName2 = "",
                AccountType = "",
                RemitAddress1 = "260 Riva ridge Ct",
                RemitAddress2 = "",
                RemitAddress3 = "",
                RemitCity = "Loveland",
                RemitCountryCode = "US",
                RemitState = "OH",
                RemitZipcode = "45140",
                EffectiveDate = "9/1/2019",
                SourceCode = "testing",
                TranHdrDesc = "VUOCK",
                RecvPartAcctType = string.Empty
            },
            new AP {
                Id = 2,
                StatusInd = "D",
                Bank = "Ken's Bank",
                BankAcctNbr = "1111111111111",
                BankAcctTransit = "11111111",
                RcrsTransitRoute = "111018214",
                RcrsAccountNum = "17511411412151",
                CompanyCode = "KEN",
                DiscountAmt = 0,
                EftAdviceNum = "5799",
                EftAmt = 36.67m,
                CheckNumber = "",
                CheckDate = "9/23/2019",
                CheckAmt = 36.67m,
                EftTraceNum = "11111111115816",
                EntryDate = "5/2/1991",
                InvoiceAmt = 36.67m,
                InvoiceDate = "9/30/2019",
                NetInvoiceAmt = 36.67m,
                PayDate = "10/1/2019",
                PaymentId = "1111113",
                PaymentMode = "E",
                TinType = "P",
                VendorId = "AG530393",
                VendorName1 = "GREG DOUD",
                GenericName2 = "",
                AccountType = "C",
                RemitAddress1 = "260 Riva ridge Ct",
                RemitAddress2 = "",
                RemitAddress3 = "",
                RemitCity = "Loveland",
                RemitCountryCode = "US",
                RemitState = "OH",
                RemitZipcode = "45140",
                EffectiveDate = "9/1/2019",
                SourceCode = "TESTING2",
                TranHdrDesc = "VUEFT",
                RecvPartAcctType = "C"
            },
            new AP {
                Id = 3,
                StatusInd = "D",
                Bank = "Invalid Bank",
                BankAcctNbr = "1010101010101",
                BankAcctTransit = "10101010",
                RcrsTransitRoute = "101010204",
                RcrsAccountNum = "10501010402050",
                CompanyCode = "BAD",
                DiscountAmt = 0,
                EftAdviceNum = "9999",
                EftAmt = 12.34m,
                CheckNumber = "",
                CheckDate = "12/31/1970",
                CheckAmt = 12.34m,
                EftTraceNum = "10101010105010",
                EntryDate = "12/31/1991",
                InvoiceAmt = 12.34m,
                InvoiceDate = "8/27/1957",
                NetInvoiceAmt = 12.34m,
                PayDate = "09/27/1957",
                PaymentId = "1010103",
                PaymentMode = "X",
                TinType = "P",
                VendorId = "XX666666",
                VendorName1 = "Scrooge",
                GenericName2 = "",
                AccountType = "C",
                RemitAddress1 = "123 Any St",
                RemitAddress2 = "",
                RemitAddress3 = "",
                RemitCity = "Anytown",
                RemitCountryCode = "XX",
                RemitState = "ZZ",
                RemitZipcode = "12345",
                EffectiveDate = "10/31/1957",
                SourceCode = "INVALID-TRAN",
                TranHdrDesc = "VUXXX",
                RecvPartAcctType = "S"
            }
        };
        #region Properties
        public int Id { get; set; }
        public string StatusInd { get; set; }
        public string Bank { get; set; }
        public string BankAcctNbr { get; set; }
        public string BankAcctTransit { get; set; }
        public string RcrsTransitRoute { get; set; }
        public string RcrsAccountNum { get; set; }
        public string CompanyCode { get; set; }
        public decimal DiscountAmt { get; set; }
        public string EftAdviceNum { get; set; }
        public decimal EftAmt { get; set; }
        public string CheckNumber { get; set; }
        public string CheckDate { get; set; }
        public decimal CheckAmt { get; set; }
        public string EftTraceNum { get; set; }
        public string EntryDate { get; set; }
        public decimal InvoiceAmt { get; set; }
        public string InvoiceDate { get; set; }
        public decimal NetInvoiceAmt { get; set; }
        public string PayDate { get; set; }
        public string PaymentId { get; set; }
        public string PaymentMode { get; set; }
        public string TinType { get; set; }
        public string VendorId { get; set; }
        public string VendorName1 { get; set; }
        public string GenericName2 { get; set; }
        public string AccountType { get; set; }
        public string RemitAddress1 { get; set; }
        public string RemitAddress2 { get; set; }
        public string RemitAddress3 { get; set; }
        public string RemitCity { get; set; }
        public string RemitCountryCode { get; set; }
        public string RemitState { get; set; }
        public string RemitZipcode { get; set; }
        public string EffectiveDate { get; set; }
        public string ReferenceData { get; set; }
        public string SourceCode { get; set; }
        public string TranHdrDesc { get; set; }
        public string RecvPartAcctType { get; set; }
        #endregion
    }
}
