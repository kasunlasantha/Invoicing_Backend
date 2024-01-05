namespace SLTInvoicingBackend.Core
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("SLTCRM.QUOTATIONHEADER")]
    public partial class QUOTATIONHEADER
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public QUOTATIONHEADER()
        {
            QUOTATIONDETAILS = new HashSet<QUOTATIONDETAIL>();
        }

        public decimal? INVOID { get; set; }

        [Key]
        [StringLength(20)]
        public string INVOICENO { get; set; }

        public decimal? ISTAX { get; set; }

        [StringLength(16)]
        public string TAXSEQNO { get; set; }

        public decimal? TAXID { get; set; }

        public DateTime? INVOICEDATE { get; set; }

        [StringLength(4)]
        public string COSTCODE { get; set; }

        public decimal? ACCODE { get; set; }

        public decimal? INVOTYPE { get; set; }

        [StringLength(100)]
        public string CUSTNAME { get; set; }

        [StringLength(100)]
        public string CUSTCONTACT { get; set; }

        [StringLength(50)]
        public string REFNO { get; set; }

        public decimal? SUBTOTAL { get; set; }

        public decimal? DISCOUNTPRECENTAGE { get; set; }

        public decimal? DISCOUNT { get; set; }

        public decimal? VAT { get; set; }

        public decimal? TOTAL { get; set; }

        public decimal? INVOICEUSER { get; set; }

        public decimal? PRINTSTAT { get; set; }

        public decimal? CANCELSTAT { get; set; }

        public DateTime? CANCELDATE { get; set; }

        public decimal? CANCELUSER { get; set; }

        public decimal? TRANSFERSTAT { get; set; }

        public decimal? OTHERCHARGES { get; set; }

        public decimal? UPLOADSTATUS { get; set; }

        public decimal? PHDISCOUNT { get; set; }

        public DateTime? RECEIPTDATE { get; set; }

        public decimal? OTHERCHARGESVAT { get; set; }

        public decimal? VATDISCOUNT { get; set; }

        [StringLength(4)]
        public string BCCODE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<QUOTATIONDETAIL> QUOTATIONDETAILS { get; set; }
    }
}
