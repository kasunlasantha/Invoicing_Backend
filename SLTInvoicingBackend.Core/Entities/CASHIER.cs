namespace SLTInvoicingBackend.Core
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("SLTCRM.CASHIER")]
    public partial class CASHIER
    {
        [Key]
        public decimal CA_ID { get; set; }

        [Required]
        [StringLength(6)]
        public string CA_SERVICEID { get; set; }

        [Required]
        [StringLength(100)]
        public string CA_NAME { get; set; }

        [Required]
        [StringLength(32)]
        public string CA_PASSWORD { get; set; }

        [Required]
        [StringLength(4)]
        public string BC_CODE { get; set; }

        public decimal CA_LEVEL { get; set; }

        public decimal? CA_SEQ_NO { get; set; }

        public DateTime? CA_LOG_DATE { get; set; }

        public DateTime? CA_CLOSE_DATE { get; set; }

        public decimal STATUS { get; set; }

        [StringLength(64)]
        public string CERTIFICATESERIAL { get; set; }

        public DateTime? CERTIFICATEEXPDATE { get; set; }

        public decimal? INVOSTATUS { get; set; }

        public decimal? CRM_SEQ_NO { get; set; }

        public virtual BILLINGCENTER BILLINGCENTER { get; set; }
    }
}
