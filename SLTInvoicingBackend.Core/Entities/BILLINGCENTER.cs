namespace SLTInvoicingBackend.Core
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("SLTCRM.BILLINGCENTER")]
    public partial class BILLINGCENTER
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BILLINGCENTER()
        {
            STOCKs = new HashSet<STOCK>();
            CASHIERs = new HashSet<CASHIER>();
            EQUIPMENTSERIALs = new HashSet<EQUIPMENTSERIAL>();
            INVOICEHEADERs = new HashSet<INVOICEHEADER>();
            STOCKMGTs = new HashSet<STOCKMGT>();
        }

        [Key]
        [StringLength(4)]
        public string BC_CODE { get; set; }

        [StringLength(10)]
        public string BC_COSTCODE { get; set; }

        [StringLength(50)]
        public string BC_DESC { get; set; }

        [StringLength(10)]
        public string BC_USERNAME { get; set; }

        public bool? BC_EODSTAMPED { get; set; }

        public decimal? BC_PAYRECON { get; set; }

        public decimal? BC_FILEGENSTAT { get; set; }

        [StringLength(18)]
        public string BC_IP { get; set; }

        public decimal? BC_LASTPID { get; set; }

        [StringLength(32)]
        public string BC_UN { get; set; }

        [StringLength(64)]
        public string BC_PW { get; set; }

        [StringLength(4)]
        public string BC_REGIONCODE { get; set; }

        public decimal? FILESEQNUM { get; set; }

        [StringLength(10)]
        public string NEWCONNCODE { get; set; }

        [StringLength(3)]
        public string CURRENCY { get; set; }

        [StringLength(100)]
        public string ANNOUNCEMENT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<STOCK> STOCKs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CASHIER> CASHIERs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EQUIPMENTSERIAL> EQUIPMENTSERIALs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<INVOICEHEADER> INVOICEHEADERs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<STOCKMGT> STOCKMGTs { get; set; }
    }
}
