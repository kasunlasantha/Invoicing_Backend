using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLTInvoicingBackend.Core.Entities
{
    public class RPTGoodsReceivedNotesDetails
    {
        public string GRNNO { get; set; }
        public string EQUCODE { get; set; }
        public string GRNDATE { get; set; }
        public string UNITPRICE { get; set; }
        public string QTY { get; set; }
        public string AMOUNT { get; set; }
        public string BC_CODE { get; set; }



        //public int GRNNO { get; set; }
        //public string EQUCODE { get; set; }
        //public string GRNDATE { get; set; }
        //public decimal UNITPRICE { get; set; }
        //public int QTY { get; set; }
        //public decimal AMOUNT { get; set; }
        //public string BC_CODE { get; set; }
    }
}
