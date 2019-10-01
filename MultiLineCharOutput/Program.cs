using MultiLineCharOutput.OrigPartyNameAddress;
using MultiLineCharOutput.Payment;
using System;
using System.Collections.Generic;

namespace MultiLineCharOutput {

    public class PaymentMode {
        public const string Check = "C";
        public const string Eft = "E";
    }

    class Program {

        List<string> linesOut = new List<string>();

        void Run() {
            var hdr = new Header();
            AppendToOutput(hdr.ToFixedTextLine());

            BasePayment pymt = null;
            BaseOrigPartyNameAddress origNameAddr = null;
            var aplist = AP.SqlQueryAp;
            foreach(var ap in aplist) {
                switch(ap.PaymentMode) {
                    case PaymentMode.Check:
                        pymt = new CheckPayment(ap);
                        origNameAddr = new CheckOrigPartyNameAddress(ap);
                        break;
                    case PaymentMode.Eft:
                        pymt = new EftPayment(ap);
                        origNameAddr = new EftOrigPartyNameAddress(ap);
                        break;
                    default:
                        pymt = new UnknownPayment(ap);
                        origNameAddr = new OtherOrigPartyNameAddress(ap);
                        break;
                }
                AppendToOutput(pymt.ToFixedTextLine());
                AppendToOutput(origNameAddr.ToFixedTextLine());
            }
        }
        void AppendToOutput(string msg) {
            linesOut.Add(msg);
            System.Diagnostics.Debug.WriteLine(msg);
        }
        static void Main(string[] args) {
            (new Program()).Run();
        }
        void TestPrototype() { 
            var or1 = new OutRec();
            or1.OutLine1.Field1 = "ABCDEFGHIJ";
            or1.OutLine1.Field2 = "XXXXX";
            or1.OutLine1.Field3 = "YYY";
            or1.OutLine2.Field1 = "0123456789";
            or1.OutLine2.Field2 = "ZZZ";
            or1.OutLine2.Field3 = "AAAAAAA";
            or1.OutLine2.Field4 = 123;
            or1.OutLine2.Field5 = 987;
            or1.OutLine3.Field1 = "Gregory";
            or1.OutLine3.Field2 = "P";
            or1.OutLine3.Field3 = "Doud";
            or1.ToLines().ForEach(l => Console.WriteLine(l));
        }
    }
}
