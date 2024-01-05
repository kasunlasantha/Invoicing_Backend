using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLTInvoicingBackend.Core.Entities
{
    public class EQUIPMENTLIST
    {
        public string EQUCODE { get; set; }
        public string EQUNAME { get; set; }
        public string BARCODE { get; set; }
        public int QtyinHand { get; set; }
        public string DESCRIPTION { get; set; }
        public decimal REVCOST { get; set; }
        public decimal REVMARKUP { get; set; }
        public decimal REVSELLING { get; set; }
        
    }
}
