using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SLTInvoicingBackend.WebAPI.DTOs
{
    public class RPTInvoiceDetailsDTO
    {
        public string BCENTERNAME { get; set; }
        public string DATETO { get; set; }
        public string DATEFROM { get; set; }
        public string SELECTGOODS { get; set; }
        public string TAXTYPE { get; set; }
        public string STATUS { get; set; }
    }
}