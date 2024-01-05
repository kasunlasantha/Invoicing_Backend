using log4net;
using SLTInvoicingBackend.Core.ApplicationServices;
using SLTInvoicingBackend.Core.Entities;
using SLTInvoicingBackend.WebAPI.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace SLTInvoicingBackend.WebAPI.Controllers
{
    public class StockController : ApiController
    {
        readonly IStockService _stockservice;
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public StockController(IStockService stockservice)
        {
            _stockservice = stockservice;
           
        }

        [HttpPost]
        [ActionName("getStockInHandbyEqucode")]
        public IHttpActionResult getStockInHandbyEqucode([FromBody]EquCenterDTO equ)
        {
            try
            {
                var stock_in_hand = _stockservice.GetStockInHand(equ.equcode,equ.center);
            
                return Ok(stock_in_hand);
            }
            catch (Exception e)
            {
                log.Error(e);
                throw new HttpResponseException(
                                   Request.CreateErrorResponse(HttpStatusCode.NotFound, e.Message + "." + e.InnerException));
            }

        }


        [HttpPost]
        [ActionName("GetCurrentStockLevel")]
        [ResponseType(typeof(List<RPTCURRENTSTOCKLEVEL>))]
        public IHttpActionResult GetCurrentStockLevel([FromBody]string code)
        {
            try
            {
                var dtStock = _stockservice.GetCurrentStockLevel(code);
                //var equList = _mapper.Map<IList<EquipmentDTO>>(Equ);
                return Ok(dtStock);

            }
            catch (Exception e)
            {
                log.Error(e);
                throw new HttpResponseException(
                                   Request.CreateErrorResponse(HttpStatusCode.NotFound, e.Message + "." + e.InnerException));
            }

        }

        
    }
}
