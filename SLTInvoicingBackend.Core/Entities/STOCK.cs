namespace SLTInvoicingBackend.Core
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("SLTCRM.STOCK")]
    public partial class STOCK
    {
        public decimal STOCKID { get; set; }

        [Required]
        [StringLength(12)]
        public string EQUCODE { get; set; }

        [Required]
        [StringLength(4)]
        public string BC_CODE { get; set; }

        public decimal? RECEIVEDQTY { get; set; }

        public decimal? SOLDQTY { get; set; }

        public decimal? RESERVEDQTY { get; set; }

        public decimal? DEFECTEDQTY { get; set; }

        public decimal? EQUTYPE { get; set; }
      

        public virtual BILLINGCENTER BILLINGCENTER { get; set; }

        public virtual EQUIPMENT EQUIPMENT { get; set; }
    }
}
