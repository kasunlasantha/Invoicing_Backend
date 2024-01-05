namespace SLTInvoicingBackend.Core
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("SLTCRM.COSTCENTER")]
    public partial class COSTCENTER
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public COSTCENTER()
        {
            INVOICEHEADERs = new HashSet<INVOICEHEADER>();
            STOCKMGTs = new HashSet<STOCKMGT>();
        }

        public decimal CENTERID { get; set; }

        [Key]
        [StringLength(4)]
        public string CENTERCODE { get; set; }

        [StringLength(100)]
        public string CENTERNAME { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<INVOICEHEADER> INVOICEHEADERs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<STOCKMGT> STOCKMGTs { get; set; }
    }
}
