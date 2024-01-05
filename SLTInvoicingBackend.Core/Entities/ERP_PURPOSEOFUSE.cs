namespace SLTInvoicingBackend.Core
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("SLTCRM.ERP_PURPOSEOFUSE")]
    public partial class ERP_PURPOSEOFUSE
    {
        [Key]
        public decimal PURPOSEID { get; set; }

        public decimal? TRANSACTION_TYPE { get; set; }

        [StringLength(50)]
        public string PURPOSE { get; set; }
    }
}
