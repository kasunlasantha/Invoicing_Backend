using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLTInvoicingBackend.Core.Entities
{
    public class RPTDEFECTSUMMARY
    {
        public string DEFECTNO { get; set; }
        public string INVOICENO { get; set; }
        public string ITEMCODE { get; set; }
        public int NOOFITEMS { get; set; }
        public DateTime RECORDDATE { get; set; }
        public string STRUSER { get; set; }
        public string DEFECTSERIAL { get; set; }
        public string NEWSERIAL { get; set; }
        public string BCCODE { get; set; }
    }
}
