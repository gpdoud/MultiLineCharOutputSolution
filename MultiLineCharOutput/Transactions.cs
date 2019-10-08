using System;
using System.Collections.Generic;
using System.Text;

namespace MultiLineCharOutput {
    
    public class Transactions : List<Transaction> {

        public IList<string> ToStringList() {
            var outLines = new List<string>();
            var lastKey = string.Empty;
            foreach(var tran in this) {
                if(!lastKey.Equals(tran.Key)) {
                    outLines.Add(tran.Payment.ToFixedTextLine());
                    outLines.Add(tran.OrigPartyNameAddress.ToFixedTextLine());
                    outLines.Add(tran.RecvPartyNameAddress.ToFixedTextLine());
                }
                outLines.Add(tran.Invoice.ToFixedTextLine());
                lastKey = tran.Key;
            }
            return outLines;
        }

        public Transactions() : base() { }
    }
}
