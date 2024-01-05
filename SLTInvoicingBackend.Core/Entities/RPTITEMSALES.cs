using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLTInvoicingBackend.Core.Entities
{
    public class RPTITEMSALES
    {
        public string ITEMCODE { get; set; }
        public int QTY { get; set; }
        public decimal AMT { get; set; }
        public string EQUNAME { get; set; }
        public string CENTERCODE { get; set; }
    }
}
