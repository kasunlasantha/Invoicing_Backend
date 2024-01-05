namespace SLTInvoicingBackend.Core
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("SLTCRM.EQUIPMENT")]
    public partial class EQUIPMENT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public EQUIPMENT()
        {
            DEFECTGOODS = new HashSet<DEFECTGOOD>();
            STOCKs = new HashSet<STOCK>();
            EQUIPMENTSERIALs = new HashSet<EQUIPMENTSERIAL>();
            INVOICEDETAILS = new HashSet<INVOICEDETAIL>();
            PRICEREVISIONS = new HashSet<PRICEREVISION>();
            RETURNGOODS = new HashSet<RETURNGOOD>();
            STOCKMGTs = new HashSet<STOCKMGT>();
        }

        public decimal? EQUID { get; set; }

        [Key]
        [StringLength(12)]
        public string EQUCODE { get; set; }

        [StringLength(32)]
        public string EQUNAME { get; set; }

        public decimal? VENDOR { get; set; }

        public decimal? SUPPLIER { get; set; }

        public decimal? STATUS { get; set; }

        public DateTime? LASTUPDATE { get; set; }

        [StringLength(32)]
        public string BARCODE { get; set; }

        public decimal? REORDERLEVEL { get; set; }

        public decimal? REORDERQTY { get; set; }

        public decimal? SELLING { get; set; }

        public decimal? MARKUP { get; set; }

        public decimal? COST { get; set; }

        [StringLength(9)]
        public string ACCOUNTSCODE { get; set; }

        public decimal? EQUTYPE { get; set; }

        public decimal? EQUBLOCK { get; set; }

        public decimal? WARRANTY { get; set; }
              
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DEFECTGOOD> DEFECTGOODS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<STOCK> STOCKs { get; set; }

        public virtual VENDOR VENDOR1 { get; set; }

        public virtual SUPPLIER SUPPLIER1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EQUIPMENTSERIAL> EQUIPMENTSERIALs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<INVOICEDETAIL> INVOICEDETAILS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PRICEREVISION> PRICEREVISIONS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RETURNGOOD> RETURNGOODS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<STOCKMGT> STOCKMGTs { get; set; }
    }
}
