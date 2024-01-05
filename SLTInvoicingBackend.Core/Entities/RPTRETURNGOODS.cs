using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLTInvoicingBackend.Core.Entities
{
    public class RPTRETURNGOODS
    {
        public string INVOICENO { get; set; }//VARCHAR2(50 BYTE)
        public string ITEMCODE { get; set; }//VARCHAR2(12 BYTE)
        public decimal NOOFITEMS { get; set; }//NUMBER(38,0)
        public string OPTIONTYPE { get; set; }//NUMBER(38,0)
        public string NEWINVOICENO { get; set; }//VARCHAR2
        public string RETURNINVNO { get; set; }//VARCHAR2(18)
        public string NEWITEMCODE { get; set; }//VARCHAR2(12 BYTE)
        public string NEWQTY { get; set; }//NUMBER(38,0)
        //public string CENTERCODE { get; set; }//VARCHAR2(8 BYTE)
    }
}
