using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLTInvoicingBackend.Core.Entities
{
    public class RPTRETURNNOTE
    {
        public string RETURNNO { get; set; }
        public string INVOICENO { get; set; }
        public string ITEMCODE { get; set; }
        public int NOOFITEMS { get; set; }
        public decimal RETURNAMT { get; set; }
        public string RETURNSERIAL { get; set; }
        public string NEWITEMCODE { get; set; }
        public decimal NEWQTY { get; set; }
        public decimal NEWAMT { get; set; }
        public string NEWSERIAL { get; set; }
        public DateTime RECORDDATE { get; set; }
        public string STRUSER { get; set; }
        public int OPTIONTYPE { get; set; }
        public string CENTERCODE { get; set; }
        public string ACCOUNTSCODE { get; set; }
    }
}
