using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLTInvoicingBackend.Core.Entities
{
    public class RPTRETURNSUMMARY
    {
        public string RETURNNO { get; set; }//VARCHAR2(14 BYTE)
        //public string INVOICENO { get; set; }//VARCHAR2(50 BYTE)
        public string ITEMCODE { get; set; }//VARCHAR2(12 BYTE)
        public decimal NOOFITEMS { get; set; }//NUMBER(38,0)
        public decimal RETURNAMT { get; set; }//NUMBER(18,2)
        //public string RETURNSERIAL { get; set; }//VARCHAR2(100 BYTE)
        public string NEWITEMCODE { get; set; }//VARCHAR2(12 BYTE)
        public string NEWQTY { get; set; }//NUMBER(38,0)
        public string NEWAMT { get; set; }//NUMBER(18,2)
        //public string NEWSERIAL { get; set; }//VARCHAR2(100 BYTE)
        public string RECORDDATE { get; set; }//VARCHAR2(100 BYTE)
        //public string STRUSER { get; set; }//VARCHAR2(20 BYTE)
        //public decimal OPTIONTYPE { get; set; }//NUMBER(38,0)
        public string CENTERCODE { get; set; }//VARCHAR2(8 BYTE)
    }
}

