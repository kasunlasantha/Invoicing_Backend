using AutoMapper;
using SLTInvoicingBackend.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SLTInvoicingBackend.WebAPI.DTOs
{
    //[AutoMap(typeof(CASHIER))]
    public class UserDTO 
    {

        public decimal CA_ID { get; set; }

        public string CA_SERVICEID { get; set; }
     
        public string BC_CODE { get; set; }
    
        public string CERTIFICATESERIAL { get; set; }

        public decimal CA_LEVEL { get; set; }

        public DateTime? CERTIFICATEEXPDATE { get; set; }
        public virtual BillingcenterDTO BILLINGCENTER { get; set; }
        //public virtual ICollection<BillingcenterDTO> BILLINGCENTER { get; set; }
    }
}