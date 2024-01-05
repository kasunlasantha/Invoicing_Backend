using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SLTInvoicingBackend.WebAPI.DTOs
{
    public class TaxDTO
    {

        public string TAXCODE { get; set; }
        public decimal TAXVALUE { get; set; }
    }
}