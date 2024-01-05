namespace SLTInvoicingBackend.Core
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("SLTCRM.REASON")]
    public partial class REASON
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public REASON()
        {
            STOCKMGTs = new HashSet<STOCKMGT>();
        }

        public decimal ID { get; set; }

        [Required]
        [StringLength(50)]
        public string DESCRIPTION { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<STOCKMGT> STOCKMGTs { get; set; }
    }
}
