namespace SLTInvoicingBackend.Core
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("SLTCRM.EQUIPMENTSERIAL")]
    public partial class EQUIPMENTSERIAL
    {
        [Key]
        public decimal SERIALID { get; set; }

        [StringLength(18)]
        public string INVONO { get; set; }

        [StringLength(20)]
        public string ITEMCODE { get; set; }

        [StringLength(75)]
        public string SERIALNO { get; set; }

        [StringLength(4)]
        public string BCCODE { get; set; }

        public virtual BILLINGCENTER BILLINGCENTER { get; set; }

        public virtual EQUIPMENT EQUIPMENT { get; set; }

        public virtual INVOICEHEADER INVOICEHEADER { get; set; }
    }
}
