using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SLTInvoicingBackend.WebAPI.DTOs
{
    public class TransactionTypeDTO
    {    
        public decimal TRAN_ID { get; set; }
        public string TRAN_TYPE { get; set; }
    }
}