using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SLTInvoicingBackend.WebAPI.DTOs
{
    public class LoginDTO
    {
        [Required(ErrorMessage = "Service ID is Must")]
        public string CA_SERVICEID { get; set; }
        [Required(ErrorMessage = "Password is Must")]
        public string CA_PASSWORD { get; set; }
        [Required(ErrorMessage = "Center code is Must")]
        public string BC_CODE { get; set; }
     
       
    }
}