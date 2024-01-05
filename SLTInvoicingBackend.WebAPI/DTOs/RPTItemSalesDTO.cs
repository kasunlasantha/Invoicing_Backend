using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SLTInvoicingBackend.WebAPI.DTOs
{
    public class RPTItemSalesDTO
    {
        public string DATETO { get; set; }
        public string DATEFROM { get; set; }
        public bool RECEIPTSTAT { get; set; }
        public string ITEMCODE { get; set; }
        public string BCENTERNAME { get; set; }
    }
}