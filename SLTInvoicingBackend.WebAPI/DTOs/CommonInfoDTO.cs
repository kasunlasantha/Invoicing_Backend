using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SLTInvoicingBackend.WebAPI.DTOs
{
    public class CommonInfoDTO
    {
        public int CA_ID { get; set; }
        public string CA_SERVICEID { get; set; }
        public string BC_CODE { get; set; }
        public string INVOICENO { get; set; }
    }
}