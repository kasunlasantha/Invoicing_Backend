namespace SLTInvoicingBackend.Core
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("SLTCRM.TAX")]
    public partial class TAX
    {
        public decimal TAXID { get; set; }

        [Required]
        [StringLength(20)]
        public string TAXCODE { get; set; }

        [StringLength(128)]
        public string DESCRIPTION { get; set; }

        public decimal TAXVALUE { get; set; }

        [Required]
        [StringLength(20)]
        public string CODEUPPER { get; set; }

        [Required]
        [StringLength(20)]
        public string CODELOWER { get; set; }

        public DateTime? CREATEDDATE { get; set; }

        public DateTime? LASTUPDATE { get; set; }

        public decimal? STATUS { get; set; }
    }
}
