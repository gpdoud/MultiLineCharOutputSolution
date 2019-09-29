using System;
using System.Collections.Generic;
using System.Text;
using MultiLineCharOutput.Debug;

namespace MultiLineCharOutput {

    public class OutLine3 {

        public string Field1 { get; set; }
        public string Field2 { get; set; }
        public string Field3 { get; set; }

        public string ToLine() {
            return "D2" 
                + $"{Field1.ToFixedString(20)}"
                + $"{Field2.ToFixedString(15)}"
                + $"{Field3.ToFixedString(10)}"
                + "";
        }

        public OutLine3() { }
    }
}
