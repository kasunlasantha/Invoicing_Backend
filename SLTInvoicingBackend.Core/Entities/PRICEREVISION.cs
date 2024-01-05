namespace SLTInvoicingBackend.Core
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("SLTCRM.PRICEREVISIONS")]
    public partial class PRICEREVISION
    {
        [Key]
        public decimal PRICEPLANID { get; set; }

        [Required]
        [StringLength(12)]
        public string EQUCODE { get; set; }

        public DateTime? STARTING { get; set; }

        public DateTime? ENDING { get; set; }

        public decimal? DISCOUNTRS { get; set; }

        public decimal? DISCOUNTPV { get; set; }

        public decimal? STATUS { get; set; }

        public DateTime? LASTUPDATE { get; set; }

        [StringLength(50)]
        public string DESCRIPTION { get; set; }

        public decimal? TYPE { get; set; }

        public decimal? ACTIVE { get; set; }

        [StringLength(4)]
        public string CENTER { get; set; }

        public decimal? REVCOST { get; set; }

        public decimal? REVMARKUP { get; set; }

        public decimal? REVSELLING { get; set; }

        public decimal? EXSELLING { get; set; }

        public virtual EQUIPMENT EQUIPMENT { get; set; }
    }
}
