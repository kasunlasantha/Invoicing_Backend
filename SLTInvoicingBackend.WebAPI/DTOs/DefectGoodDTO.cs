using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SLTInvoicingBackend.WebAPI.DTOs
{
    public class DefectGoodDTO
    {
        public DefectGoodDTO()
        {
            ERP_UPLOAD_STATUS = 0;
            TRYCOUNT = 0;
        }

        [Key]
        [StringLength(14)]
        public string DEFECTNO { get; set; }

        public decimal? DEFSEQ { get; set; }

        [StringLength(50)]
        public string INVOICENO { get; set; }

        [StringLength(12)]
        public string ITEMCODE { get; set; }

        public decimal? NOOFITEMS { get; set; }

        public decimal? RETURNNEWITEMS { get; set; }

        public DateTime? RECORDDATE { get; set; }

        [StringLength(20)]
        public string STRUSER { get; set; }

        public decimal? PRINTSTAT { get; set; }

        [StringLength(100)]
        public string DEFECTSERIAL { get; set; }

        [StringLength(100)]
        public string NEWSERIAL { get; set; }

        public decimal? STATUS { get; set; }

        public decimal? ERP_UPLOAD_STATUS { get; set; }

        [StringLength(100)]
        public string ERROR_CODE { get; set; }

        public decimal? TRYCOUNT { get; set; }

        [StringLength(4)]
        public string BCCODE { get; set; }

        [StringLength(100)]
        public string DEFECT_REASON { get; set; }


    }
}