﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SLTInvoicingBackend.WebAPI.DTOs
{
    public class InvoicedtDTO
    {
        public InvoicedtDTO()
        {
            ERP_UPLOAD_STATUS = 0;
            TRYCOUNT = 0;
            IS_RETURNED = 0;

        }

        public decimal INVODEID { get; set; }

        [StringLength(18)]
        public string INVOICENO { get; set; }

        [StringLength(12)]
        public string ITEMCODE { get; set; }

        public decimal? ITEMSEQ { get; set; }

        public decimal? QTY { get; set; }

        public decimal? AMOUNT { get; set; }

        [StringLength(250)]
        public string SERIALS { get; set; }

        [StringLength(18)]
        public string RECEIPTNO { get; set; }

        public decimal? ACCODE { get; set; }

        public decimal? UNITPRICE { get; set; }

        public decimal? MARKUPPRICE { get; set; }

        public decimal? COSTPRICE { get; set; }

        public decimal? UNITPRICED { get; set; }

        public decimal? UNITPRICEF { get; set; }

        public decimal? CODAAMOUNT { get; set; }

        [StringLength(30)]
        public string MOVEORDERNO { get; set; }

        public decimal? ERP_UPLOAD_STATUS { get; set; }

        public decimal? TRYCOUNT { get; set; }

        [StringLength(100)]
        public string RETURN_CODE { get; set; }

        [StringLength(250)]
        public string RETURN_MESSAGE { get; set; }

        public decimal? IS_RETURNED { get; set; }

    }
}