using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SLTInvoicingBackend.WebAPI.DTOs
{
    public class StockDTO
    {
        public string BC_CODE { get; set; }

        public string EQUCODE { get; set; }

        public decimal? RECEIVEDQTY { get; set; }

        public decimal? SOLDQTY { get; set; }

        public decimal? RESERVEDQTY { get; set; }

        public decimal? DEFECTEDQTY { get; set; }
    }
}