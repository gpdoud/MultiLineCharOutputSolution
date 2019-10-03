using MultiLineCharOutput.Release;
using System;
using System.Collections.Generic;
using System.Text;

namespace MultiLineCharOutput.RecvPartyNameAddress {

    public class BaseRecvPartyNameAddress : IFixedTextLine {

        public string RecordId { get; set; } = "PA";
        public string AddressInd { get; set; } = "PE";
        public string Name { get; set;  }

        public string ToFixedTextLine() {
            var sb = new StringBuilder();

            sb.Append(this.RecordId.ToFixedString(2));
            sb.Append(this.AddressInd.ToFixedString(2));
            sb.Append(this.Name.ToFixedString(60));

            return sb.ToString();
        }

        public BaseRecvPartyNameAddress(AP ap) {
            this.Name = ap.VendorName1;
        }
    }
}
