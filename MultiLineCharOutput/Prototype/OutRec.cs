using System;
using System.Collections.Generic;
using System.Text;

namespace MultiLineCharOutput {

    public class OutRec {
        public OutLine1 OutLine1 { get; set; }
        public OutLine2 OutLine2 { get; set; }
        public OutLine3 OutLine3 { get; set; }

        public List<string> ToLines() {
            List<string> lines = new List<string>();
            lines.Add(OutLine1.ToLine());
            lines.Add(OutLine2.ToLine());
            lines.Add(OutLine3.ToLine());
            return lines;
        }

        public OutRec() {
            OutLine1 = new OutLine1();
            OutLine2 = new OutLine2();
            OutLine3 = new OutLine3();
        }
    }
}
