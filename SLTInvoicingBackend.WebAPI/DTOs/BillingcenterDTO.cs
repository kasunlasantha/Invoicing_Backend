using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SLTInvoicingBackend.WebAPI.DTOs
{
    public class BillingcenterDTO
    {
        [StringLength(4)]
        public string BC_CODE { get; set; }

        [StringLength(10)]
        public string BC_COSTCODE { get; set; }

        [StringLength(50)]
        public string BC_DESC { get; set; }  //21914 5844

        [StringLength(100)]
        public string ANNOUNCEMENT { get; set; }
    }
}