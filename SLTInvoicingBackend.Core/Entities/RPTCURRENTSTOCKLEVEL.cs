using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLTInvoicingBackend.Core.Entities
{
    public class RPTCURRENTSTOCKLEVEL
    {
        public string ItemCode { get; set; }
        public string ItemDescription { get; set; }
         public int EQUBLOCK { get; set; }
        public int ReservedQTY { get; set; }
        public int DefectedQTY { get; set; }
        public int ReceivedQTY { get; set; }
        public int SoldQTY { get; set; }
        public int QTY_InHand { get; set; }
        public string EQU_TYPE { get; set; }
        
    }
}
