using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SLTInvoicingBackend.WebAPI.DTOs
{
    public class ItemSalesDTO
    {
        public string ITEMCODE { get; set; }
        public int QTY { get; set; }
        public decimal AMT { get; set; }
        public string EQUNAME { get; set; }
    }
}