namespace SLTInvoicingBackend.Core
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("SLTCRM.VENDORS")]
    public partial class VENDOR
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public VENDOR()
        {
            EQUIPMENTs = new HashSet<EQUIPMENT>();
        }

        public decimal VENDORID { get; set; }

        [Required]
        [StringLength(8)]
        public string VENDORCODE { get; set; }

        [StringLength(64)]
        public string VENDORNAME { get; set; }

        [StringLength(128)]
        public string ADDRESS { get; set; }

        [StringLength(64)]
        public string CONTACTPERSON { get; set; }

        [StringLength(32)]
        public string TELEPHONE { get; set; }

        [StringLength(50)]
        public string FAX { get; set; }

        public decimal? STATUS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EQUIPMENT> EQUIPMENTs { get; set; }
    }
}
