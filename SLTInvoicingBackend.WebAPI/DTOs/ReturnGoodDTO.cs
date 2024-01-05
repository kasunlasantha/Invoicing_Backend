using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SLTInvoicingBackend.WebAPI.DTOs
{
    public class ReturngdDTO
    {
        public ReturngdDTO()
        {
            ERP_UPLOAD_STATUS = 0;
            TRYCOUNT = 0;
        }

        [Key]
        [StringLength(14)]
        public string RETURNNO { get; set; }

        public decimal? RETSEQ { get; set; }

        [StringLength(50)]
        public string INVOICENO { get; set; }

        [StringLength(12)]
        public string ITEMCODE { get; set; }

        public decimal? NOOFITEMS { get; set; }

        public decimal? OPTIONTYPE { get; set; }

        [StringLength(12)]
        public string NEWITEMCODE { get; set; }

        public decimal? NEWQTY { get; set; }

        public DateTime? RECORDDATE { get; set; }

        [StringLength(20)]
        public string STRUSER { get; set; }

        public decimal? AMOUNT { get; set; }

        public decimal? RETURNAMT { get; set; }

        [StringLength(100)]
        public string RETURNSERIAL { get; set; }

        public decimal? NEWAMT { get; set; }

        [StringLength(100)]
        public string NEWSERIAL { get; set; }

        public decimal? STATUS { get; set; }

        public decimal? ERP_UPLOAD_STATUS { get; set; }

        public decimal? TRYCOUNT { get; set; }

        [StringLength(100)]
        public string ERROR_CODE { get; set; }

        [StringLength(8)]
        public string CENTERCODE { get; set; }

        public decimal? IS_COMPLETE { get; set; }

    }
}