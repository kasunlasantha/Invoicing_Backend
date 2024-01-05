using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLTInvoicingBackend.Core.Entities
{
    public class RPTINVOICESUMMARY
    {
        public string INVOICENO { get; set; }
        public string INVOICEDATE { get; set; }
        public decimal TOTAL { get; set; }
        public decimal DISCOUNT { get; set; }
        public decimal PHDISCOUNT { get; set; }
        public string BCCODE { get; set; }
    }
}
