using MultiLineCharOutput.Invoice;
using MultiLineCharOutput.OrigPartyNameAddress;
using MultiLineCharOutput.Payment;
using MultiLineCharOutput.RecvPartyNameAddress;
using System;
using System.Collections.Generic;
using System.Text;

namespace MultiLineCharOutput {

    public class Transaction {
        public string Key { get; set; } // normally EftAdviceNum
        public BasePayment Payment { get; set; }
        public BaseOrigPartyNameAddress OrigPartyNameAddress { get; set; }
        public BaseRecvPartyNameAddress RecvPartyNameAddress { get; set; }
        public BaseInvoice Invoice { get; set; }

        public Transaction() {
        }

    }
}
