namespace SLTInvoicingBackend.Core
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("SLTCRM.STOCKMGT")]
    public partial class STOCKMGT
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [Column(Order = 0)]
        public decimal MGTID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(12)]
        public string EQUCODE { get; set; }

        [StringLength(10)]
        public string BC_CODE { get; set; }

        [StringLength(4)]
        public string COSTCODE { get; set; }

        [StringLength(20)]
        public string INVOICENO { get; set; }

        public decimal? RECEIVED_QTY { get; set; }

        public decimal? SOLD_QTY { get; set; }

        public decimal? RESERVED_QTY { get; set; }

        public decimal? DEFECTED_QTY { get; set; }

        public decimal? INCREASED_QTY { get; set; }

        public decimal? DECREASED_QTY { get; set; }

        public decimal? OPENING_QTY { get; set; }

        public decimal? CLOSING_QTY { get; set; }

        public decimal? STATUS { get; set; }

        public DateTime? REFDATE { get; set; }

        public decimal? ENTRYTYPE { get; set; }

        public decimal? REASONID { get; set; }

        public decimal? UPLOADSTATUS { get; set; }

        public decimal? EQUTYPE { get; set; }

        public decimal? RETURN_QTY { get; set; }

        public virtual BILLINGCENTER BILLINGCENTER { get; set; }

        public virtual COSTCENTER COSTCENTER { get; set; }

        public virtual EQUIPMENT EQUIPMENT { get; set; }

        public virtual REASON REASON { get; set; }
    }
}
