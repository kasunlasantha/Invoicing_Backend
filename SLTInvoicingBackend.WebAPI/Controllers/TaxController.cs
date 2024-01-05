using AutoMapper;
using log4net;
using SLTInvoicingBackend.Core.ApplicationServices;
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
    public class TaxController : ApiController
    {
        readonly ITaxService _taxservice;
        IMapper _mapper;
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public TaxController(ITaxService taxService, IMapper mapper)
        {
            _taxservice = taxService;
            _mapper = mapper;
        }

        [HttpPost]
        [ActionName("getTxbyEqucode")]
        [ResponseType(typeof(List<TaxDTO>))]
        public IHttpActionResult getEquipmentbyCenter([FromBody]string code)
        {
            try
            {
                var Tax = _taxservice.GetTaxByequcode(code);
                var taxList = _mapper.Map<IList<TaxDTO>>(Tax);
                return Ok(taxList);
            }
            catch (Exception e)
            {
                log.Error(e);
                throw new HttpResponseException(
                                   Request.CreateErrorResponse(HttpStatusCode.NotFound, e.Message + "." + e.InnerException));
            }

        }

        [HttpPost]
        [ActionName("getTaxbyTaxcode")]
        [ResponseType(typeof(List<TaxDTO>))]
        public IHttpActionResult getTaxbyTaxcode([FromBody]string code)
        {
            try
            {
                var Tax = _taxservice.GetTaxByCode(code);
                var taxList = _mapper.Map<TaxDTO>(Tax);
                return Ok(taxList);
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
