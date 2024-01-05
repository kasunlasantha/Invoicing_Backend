using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SLTInvoicingBackend.WebAPI.DTOs
{
    public class QuotationhdDTO
    {
        public QuotationhdDTO()
        {

            OTHERCHARGESVAT = 0;
            VATDISCOUNT = 0;
            PHDISCOUNT = 0;
            UPLOADSTATUS = 0;
            TRANSFERSTAT = 0;
            DISCOUNTPRECENTAGE = 0;
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

        public virtual ICollection<QuotationdtDTO> QUOTATIONDETAILS { get; set; }
    }
}