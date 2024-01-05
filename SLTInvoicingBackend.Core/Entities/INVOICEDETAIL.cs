namespace SLTInvoicingBackend.Core
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("SLTCRM.INVOICEDETAILS")]
    public partial class INVOICEDETAIL
    {
        public INVOICEDETAIL()
        {
            ERP_UPLOAD_STATUS = 0;
            TRYCOUNT = 0;
            IS_RETURNED = 0;
            CANCEL_ERP_SENT = 0;
            CANCEL_TRYCOUNT = 0;
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public decimal INVODEID { get; set; }

        [StringLength(18)]
        public string INVOICENO { get; set; }

        [StringLength(12)]
        public string ITEMCODE { get; set; }

        public decimal? ITEMSEQ { get; set; }

        public decimal? QTY { get; set; }

        public decimal? AMOUNT { get; set; }

        [StringLength(250)]
        public string SERIALS { get; set; }

        [StringLength(18)]
        public string RECEIPTNO { get; set; }

        public decimal? ACCODE { get; set; }

        public decimal? UNITPRICE { get; set; }

        public decimal? MARKUPPRICE { get; set; }

        public decimal? COSTPRICE { get; set; }

        public decimal? UNITPRICED { get; set; }

        public decimal? UNITPRICEF { get; set; }

        public decimal? CODAAMOUNT { get; set; }

        [StringLength(30)]
        public string MOVEORDERNO { get; set; }

        public decimal? ERP_UPLOAD_STATUS { get; set; }

        public decimal? TRYCOUNT { get; set; }

        [StringLength(100)]
        public string RETURN_CODE { get; set; }

        [StringLength(250)]
        public string RETURN_MESSAGE { get; set; }

        [StringLength(100)]
        public string CANCEL_RETURN_CODE { get; set; }

        [StringLength(250)]
        public string CANCEL_RETURN_MESSAGE { get; set; }

        public decimal? CANCEL_ERP_SENT { get; set; }

        public decimal? CANCEL_TRYCOUNT { get; set; }

        public virtual ACCOUNTCODE ACCOUNTCODE { get; set; }

        public virtual EQUIPMENT EQUIPMENT { get; set; }

        public virtual INVOICEHEADER INVOICEHEADER { get; set; }

        public decimal? IS_RETURNED { get; set; }
    }
}
