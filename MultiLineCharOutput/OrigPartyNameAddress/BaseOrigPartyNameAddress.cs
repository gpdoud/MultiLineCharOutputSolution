using MultiLineCharOutput.Release;
using System;
using System.Collections.Generic;
using System.Text;

namespace MultiLineCharOutput.OrigPartyNameAddress {
    
    public abstract class BaseOrigPartyNameAddress : IFixedTextLine {

        public string RecordId { get; set; } = "PA";
        public string AddressInd { get; set; } = "PR";
        public string OrigPartyName { get; set; } = "GERBER LIFE INSURANCE COMPANY";
        public string OrigPartyName2 { get; set; } = string.Empty;
        public string OrigPartyStreetAddress { get; set; } = "1311 MAMARONECK AVE";
        public string OrigPartyStreetAddress2 { get; set; } = string.Empty;
        public string OrigPartyStreetAddress3 { get; set; } = string.Empty;
        public string OrigPartyCity { get; set; } = "WHITE PLANS";
        public string OrigPartyState { get; set; } = "NY";
        public string OrigPartyPostalCode { get; set; } = "10605";
        public string OrigPartyCountryCode { get; set; } = "US";
        public string OrigPartyCountryName { get; set; } = string.Empty;
        public string OrigPartyContactEmailAddress { get; set; } = string.Empty;
        public string OrigPartyContactPhoneNumber { get; set; } = string.Empty;

        public string ToFixedTextLine() {
            var sb = new StringBuilder();

            sb.Append(this.RecordId.ToFixedString(2));
            sb.Append(this.AddressInd.ToFixedString(2));
            sb.Append(this.OrigPartyName.ToFixedString(60));
            sb.Append(this.OrigPartyName2.ToFixedString(60));
            sb.Append(this.OrigPartyStreetAddress.ToFixedString(55));
            sb.Append(this.OrigPartyStreetAddress2.ToFixedString(55));
            sb.Append(this.OrigPartyStreetAddress3.ToFixedString(55));
            sb.Append(this.OrigPartyCity.ToFixedString(30));
            sb.Append(this.OrigPartyState.ToFixedString(3));
            sb.Append(this.OrigPartyPostalCode.ToFixedString(9));
            sb.Append(this.OrigPartyCountryCode.ToFixedString(2));
            sb.Append(this.OrigPartyCountryName.ToFixedString(30));
            sb.Append(this.OrigPartyContactEmailAddress.ToFixedString(80));
            sb.Append(this.OrigPartyContactPhoneNumber.ToFixedString(10));

            return sb.ToString();
        }

        public BaseOrigPartyNameAddress(AP ap) {

        }
    }
}
