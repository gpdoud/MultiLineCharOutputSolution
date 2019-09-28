using System;

namespace MultiLineCharOutput {

    class Program {

        void Run() {
            var hdr = new Header();
            var cpymt = new Payment("C");
            var epymt = new Payment("E");
            Debug(hdr.ToFixedTextLine());
            Debug(cpymt.ToFixedTextLine());
            Debug(epymt.ToFixedTextLine());
        }
        void Debug(string msg) {
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
