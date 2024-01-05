using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SLTInvoicingBackend.WebAPI.DTOs
{
    public class EquipmentDTO
    {       
        public string EQUCODE { get; set; }
        public string EQUNAME { get; set; }
        public string BARCODE { get; set; }
        public string ACCOUNTSCODE { get; set; }
        public decimal? EQUTYPE { get; set; }

        public ICollection <PricerevisionDTO> PRICEREVISIONS { get; set; }
        public ICollection<StockDTO> STOCKS { get; set; }

    }

    
}