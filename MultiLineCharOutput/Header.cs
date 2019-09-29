using System;
using System.Collections.Generic;
using System.Text;
using MultiLineCharOutput.Release;

namespace MultiLineCharOutput {
    
    public class Header : IFixedTextLine {

        public string RecordId { get; } // "HD"
        public string FileControlNumber { get; } // "WF" + zero-fill 13 digit nbr
        public string FileDate { get; } // YYYY-MM-DD

        public string ToFixedTextLine() {
            var sb = new StringBuilder();
            sb.Append(this.RecordId.ToFixedString(2));
            sb.Append(this.FileControlNumber.ToFixedString(15));
            sb.Append(this.FileDate.ToFixedString(10));
            return sb.ToString();
        }

        public Header() {
            this.RecordId = "HD";
            this.FileControlNumber = "WF" + DateTime.Now.Ticks.ToString().Substring(0, 13);
            this.FileDate = DateTime.Now.ToString("yyyy-MM-dd");
        }
    }
}
