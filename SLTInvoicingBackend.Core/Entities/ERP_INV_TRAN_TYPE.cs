namespace SLTInvoicingBackend.Core
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("SLTCRM.ERP_INV_TRAN_TYPE")]
    public partial class ERP_INV_TRAN_TYPE
    {
        [Key]
        public decimal TRAN_ID { get; set; }

        [StringLength(50)]
        public string TRAN_TYPE { get; set; }
    }
}
