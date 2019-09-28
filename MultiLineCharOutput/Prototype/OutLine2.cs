using System;
using System.Collections.Generic;
using System.Text;

namespace MultiLineCharOutput {

    public class OutLine2 {

        public string Field1 { get; set; }
        public string Field2 { get; set; }
        public string Field3 { get; set; }
        public int Field4 { get; set; }
        public int Field5 { get; set; }

        public string ToLine() {
            return "D1|"
                   + $"{Field1.ToFixedString(10)}"
                   + $"|{Field2.ToFixedString(10)}"
                   + $"|{Field3.ToFixedString(10)}"
                   + $"|{Field4.ToFixedString(10)}"
                   + $"|{Field5.ToFixedStringRight(10, '0')}"
                   + "|";
        }

        public OutLine2() {}
    }
}
