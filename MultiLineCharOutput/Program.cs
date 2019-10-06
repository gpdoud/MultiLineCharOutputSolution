using MultiLineCharOutput.OrigPartyNameAddress;
using MultiLineCharOutput.Payment;
using MultiLineCharOutput.RecvPartyNameAddress;
using System;
using System.Collections.Generic;
using System.Linq;

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
            BaseRecvPartyNameAddress recvNameAddr = null;
            //var aplist = AP.SqlQueryAp;
            using(var db = new AppDbContext()) {
                foreach(var ap in db.APs.ToArray()) {
                    switch(ap.PaymentMode) {
                        case PaymentMode.Check:
                            pymt = new CheckPayment(ap);
                            origNameAddr = new CheckOrigPartyNameAddress(ap);
                            recvNameAddr = new CheckRecvPartyNameAddress(ap);
                            break;
                        case PaymentMode.Eft:
                            pymt = new EftPayment(ap);
                            origNameAddr = new EftOrigPartyNameAddress(ap);
                            recvNameAddr = new EftRecvPartyNameAddress(ap);
                            break;
                        default:
                            pymt = new UnknownPayment(ap);
                            origNameAddr = new OtherOrigPartyNameAddress(ap);
                            recvNameAddr = new OtherRecvPartyNameAddress(ap);
                            break;
                    }
                    AppendToOutput(pymt.ToFixedTextLine());
                    AppendToOutput(origNameAddr.ToFixedTextLine());
                    AppendToOutput(recvNameAddr.ToFixedTextLine());
                }
            }
            WriteToOutput(linesOut);
        }

        private void WriteToOutput(List<string> linesOut) {
            linesOut.ForEach(l => System.Diagnostics.Debug.WriteLine(l));
        }

        private void AppendToOutput(string msg) {
            linesOut.Add(msg);
        }
        void InitDb() {
            using(AppDbContext db = new AppDbContext()) {
                AP.SqlQueryAp.ToList().ForEach(ap => {
                    ap.Id = 0;
                    db.APs.Add(ap);
                });
                db.SaveChanges();
            }
        }
        static void Main(string[] args)
        {
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
