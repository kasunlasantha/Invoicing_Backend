using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLTInvoicingBackend.Core.Entities
{
    public class RPTDEFECTGOODS
    {
        public string DEFECTNO { get; set; }
        public string INVOICENO { get; set; }
        public string ITEMCODE { get; set; }
        public int NOOFITEMS { get; set; }
        public string BCCODE { get; set; }
    }
}
