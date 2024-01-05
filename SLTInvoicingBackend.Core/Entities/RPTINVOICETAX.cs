using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLTInvoicingBackend.Core.Entities
{
    public class RPTINVOICETAX
    {
        public string TAXCODE { get; set; }
        public decimal TAXVALUE { get; set; }
        public decimal? TAXAMOUNT { get; set; }
    }
}
