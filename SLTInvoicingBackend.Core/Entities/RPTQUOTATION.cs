using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLTInvoicingBackend.Core.Entities
{
    public class RPTQUOTATION
    {
        public string invoiceno { get; set; }
        public decimal othercharges { get; set; }
        public DateTime invoicedate { get; set; }
        public string costcode { get; set; }
        public string custname { get; set; }
        public string custcontact { get; set; }
        public decimal subtotal { get; set; }
        public decimal discount { get; set; }
        public decimal total { get; set; }
        public string itemcode { get; set; }
        public string equname { get; set; }
        public decimal accode { get; set; }
        public decimal unitprice { get; set; }
        public decimal UNITPRICED { get; set; }
        public int qty { get; set; }
        public decimal amount { get; set; }

        public string taxseqno { get; set; }
        public decimal vat { get; set; }
        public int invoiceuser { get; set; }//string
        public decimal invotype { get; set; }//int
        public decimal istax { get; set; }
        public string serials { get; set; }
        public decimal OTHERCHARGESVAT { get; set; }
        public string BCCODE { get; set; }

    }
}
