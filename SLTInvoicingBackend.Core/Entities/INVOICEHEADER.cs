namespace SLTInvoicingBackend.Core
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("SLTCRM.INVOICEHEADER")]
    public partial class INVOICEHEADER
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public INVOICEHEADER()
        {
            EQUIPMENTSERIALs = new HashSet<EQUIPMENTSERIAL>();
            INVOICEDETAILS = new HashSet<INVOICEDETAIL>();
            CANCELSTAT = 0;
            PRINTSTAT = 1;
            RECEIPTSTAT = 0;
            ISPAID = 0;
        }

        public decimal? INVOID { get; set; }

        [Key]
        [StringLength(18)]
        public string INVOICENO { get; set; }

        public decimal? ISTAX { get; set; }

        [StringLength(16)]
        public string TAXSEQNO { get; set; }

        public decimal? TAXID { get; set; }
  
        public DateTime? INVOICEDATE { get; set; }

        [StringLength(4)]
        public string COSTCODE { get; set; }

        public string ACCODE { get; set; }

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

        [StringLength(10)]
        public string INVOICEUSER { get; set; }

        public decimal? PRINTSTAT { get; set; }

        public decimal? CANCELSTAT { get; set; }

        public DateTime? CANCELDATE { get; set; }

        [StringLength(10)]
        public string CANCELUSER { get; set; }

        public decimal? TRANSFERSTAT { get; set; }

        public decimal? OTHERCHARGES { get; set; }

        public decimal? UPLOADSTATUS { get; set; }

        public decimal? PHDISCOUNT { get; set; }

        public DateTime? RECEIPTDATE { get; set; }

        public decimal? OTHERCHARGESVAT { get; set; }

        public decimal? VATDISCOUNT { get; set; }

        [StringLength(4)]
        public string BCCODE { get; set; }

        public decimal? ISPAID { get; set; }

        public decimal? RECEIPTSTAT { get; set; }

        public decimal? TRANSTYPE { get; set; }

        public decimal? PURPOSEOFUSE { get; set; }

        public string RETURNINVNO { get; set; }
        
        public decimal? RETURNAMOUNT { get; set; }

        //public virtual ACCOUNTCODE ACCOUNTCODE { get; set; }

        public virtual BILLINGCENTER BILLINGCENTER { get; set; }

        public virtual COSTCENTER COSTCENTER { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EQUIPMENTSERIAL> EQUIPMENTSERIALs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<INVOICEDETAIL> INVOICEDETAILS { get; set; }
    }
}
