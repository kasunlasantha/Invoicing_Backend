using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLTInvoicingBackend.Core.Entities
{
    public class RPTINVOICEHEADER
    {
        public string INVOICENO { get; set; }
        public DateTime INVOICEDATE { get; set; }
        public decimal SUBTOTAL { get; set; }
        public decimal DISCOUNT { get; set; }
        public decimal VAT { get; set; }
        public decimal TOTAL { get; set; }
        public string COSTCODE { get; set; }
        public string ACCODE { get; set; }
        public decimal OTHERCHARGES { get; set; }
        public decimal RETURNAMOUNT { get; set; }
    }
}
