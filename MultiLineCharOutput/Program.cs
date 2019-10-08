using MultiLineCharOutput.Invoice;
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
            var trans = new Transactions();

            Transaction tran = null;
            var key = string.Empty;
            //var aplist = AP.SqlQueryAp;
            using(var db = new AppDbContext()) {
                foreach(var ap in db.APs.OrderBy(a => a.EftAdviceNum).ToArray()) {
                    tran = new Transaction();
                    tran.Key = ap.EftAdviceNum;
                    switch(ap.PaymentMode) {
                        case PaymentMode.Check:
                            tran.Payment = new CheckPayment(ap);
                            tran.OrigPartyNameAddress = new CheckOrigPartyNameAddress(ap);
                            tran.RecvPartyNameAddress = new CheckRecvPartyNameAddress(ap);
                            tran.Invoice = new CheckInvoice(ap);
                            break;
                        case PaymentMode.Eft:
                            tran.Payment = new EftPayment(ap);
                            tran.OrigPartyNameAddress = new EftOrigPartyNameAddress(ap);
                            tran.RecvPartyNameAddress = new EftRecvPartyNameAddress(ap);
                            tran.Invoice = new EftInvoice(ap);
                            break;
                        default:
                            tran.Payment = new UnknownPayment(ap);
                            tran.OrigPartyNameAddress = new OtherOrigPartyNameAddress(ap);
                            tran.RecvPartyNameAddress = new OtherRecvPartyNameAddress(ap);
                            tran.Invoice = new UnknownInvoice(ap);
                            break;
                    }
                    
                    trans.Add(tran);
                }
            }
            // all done. write the output lines
            var hdr = new Header();
            linesOut.Add(hdr.ToFixedTextLine());
            linesOut.AddRange(trans.ToStringList());
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
