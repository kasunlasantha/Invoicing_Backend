namespace SLTInvoicingBackend.Core
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("SLTCRM.QUOTATIONDETAILS")]
    public partial class QUOTATIONDETAIL
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public decimal INVODEID { get; set; }

        [StringLength(20)]
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

        public virtual QUOTATIONHEADER QUOTATIONHEADER { get; set; }
    }
}
