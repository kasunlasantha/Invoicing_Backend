using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SLTInvoicingBackend.WebAPI.DTOs
{
    public class PricerevisionDTO
    {
        public decimal? DISCOUNTPV { get; set; }
        public decimal? DISCOUNTRS { get; set; }
        public string DESCRIPTION { get; set; }
        public decimal? REVCOST { get; set; }
        public decimal? REVMARKUP { get; set; }
        public decimal? REVSELLING { get; set; }
        public decimal? EXSELLING { get; set; }
    }
}