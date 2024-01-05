namespace SLTInvoicingBackend.Core
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
   

    [Table("SLTCRM.ACCOUNTCODES")]
    public partial class ACCOUNTCODE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ACCOUNTCODE()
        {
            INVOICEDETAILS = new HashSet<INVOICEDETAIL>();
            //INVOICEHEADERs = new HashSet<INVOICEHEADER>();
        }

        [Key]
        public decimal CODEID { get; set; }

        [Required]
        [StringLength(20)]
        public string CODEUPPER { get; set; }

        [Required]
        [StringLength(20)]
        public string CODELOWER { get; set; }

        [StringLength(128)]
        public string DESCRIPTION { get; set; }

        public decimal? ISBULK { get; set; }

        public DateTime? CREATEDDATE { get; set; }

        public DateTime? LASTUPDATE { get; set; }

        public decimal? STATUS { get; set; }

        public decimal? BASE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<INVOICEDETAIL> INVOICEDETAILS { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<INVOICEHEADER> INVOICEHEADERs { get; set; }
    }
}
