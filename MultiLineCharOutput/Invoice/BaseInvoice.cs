using MultiLineCharOutput.Release;
using System;
using System.Collections.Generic;
using System.Text;

namespace MultiLineCharOutput.Invoice {
    
    public class BaseInvoice : IFixedTextLine {

        public string RecordId { get; set; } = "IN";
        public string InvoiceNumber { get; set; } // max 30
        public DateTime InvoiceDate { get; set; } // max 10
        public string InvoiceDescription { get; set; } // max 80
        public decimal InvoiceNetAmount { get; set; } // max 18
        public decimal InvoiceGrossAmount { get; set; } // max 18
        public decimal DiscountTaken { get; set; } // max 18
        public string RelatedPONumber { get; set; } // max 15
        public string InvoiceType { get; set; } = "IV"; // max 2

        public string ToFixedTextLine() {
            var sb = new StringBuilder();

            sb.Append(RecordId.ToFixedString(2));
            sb.Append(InvoiceNumber.ToFixedString(100));
            sb.Append(InvoiceDate.ToString("yyyy-MM-dd").ToFixedString(10));
            sb.Append(InvoiceDescription.ToFixedString(80));
            sb.Append(InvoiceNetAmount.ToFixedStringRight(18, '0'));
            sb.Append(InvoiceGrossAmount.ToFixedStringRight(18, '0'));
            sb.Append(DiscountTaken.ToFixedStringRight(18, '0'));
            sb.Append(RelatedPONumber.ToFixedString(15));
            sb.Append(InvoiceType.ToFixedString(3));

            return sb.ToString();
        }

        public BaseInvoice(AP ap) {
            InvoiceNumber = ap.ReferenceData ?? string.Empty;
            InvoiceDate = DateTime.Parse(ap.InvoiceDate);
#warning InvoiceDescription contains payee name
            InvoiceDescription = ap.VendorName1; 
            InvoiceNetAmount = ap.NetInvoiceAmt;
#warning InvoiceGrossAmount is fixed at zero
            InvoiceGrossAmount = 0m;
            DiscountTaken = ap.DiscountAmt;
#warning RelatedPONumber is fixed at empty string
            RelatedPONumber = string.Empty;
           
        }
    }
}
