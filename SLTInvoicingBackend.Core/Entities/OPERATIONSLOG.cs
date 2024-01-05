namespace SLTInvoicingBackend.Core
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("SLTCRM.OPERATIONSLOG")]
    public partial class OPERATIONSLOG
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public decimal SEQUENCE { get; set; }

        public DateTime? EVENTDATE { get; set; }

        public DateTime? EVENTTIME { get; set; }

        public string LOGINNAME { get; set; }

        [StringLength(20)]
        public string DIVISION { get; set; }

        [StringLength(50)]
        public string OPERATION { get; set; }

        [StringLength(128)]
        public string DESCRIPTION { get; set; }

        [StringLength(255)]
        public string SIGNTEXT { get; set; }

        [Column(TypeName = "long")]
        public string SIGNATURE { get; set; }

        [StringLength(4)]
        public string BCCODE { get; set; }
    }
}
