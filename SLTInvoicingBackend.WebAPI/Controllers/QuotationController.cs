using AutoMapper;
using log4net;
using SLTInvoicingBackend.Core;
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
    public class QuotationController : ApiController
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        readonly IQuotationService _QuotationService;
        IMapper _mapper;

        public QuotationController(IQuotationService QuotationService, IMapper mapper)
        {
            _QuotationService = QuotationService;
            _mapper = mapper;
        }

        [HttpPost]
        [ActionName("getQuotationNo")]
        [ResponseType(typeof(string))]
        public IHttpActionResult getQuotationNo([FromBody]CommonInfoDTO rrData)
        {
            try
            {
                var retNo = _QuotationService.GetQuotationNo(rrData.BC_CODE, rrData.CA_SERVICEID);
                return Ok(retNo);
            }
            catch (Exception e)
            {
                log.Error(e);
                throw new HttpResponseException(
                                   Request.CreateErrorResponse(HttpStatusCode.NotFound, e.Message + "." + e.InnerException));
            }

        }

        [HttpPost]
        [ActionName("createQuotation")]
        [ResponseType(typeof(QuotationhdDTO))]
        public IHttpActionResult createQuotation([FromBody]QuotationhdDTO quotation)
        {
            try
            {
                var mapQuotation = _mapper.Map<QUOTATIONHEADER>(quotation);
                var createdQuotation = _QuotationService.CREATE(mapQuotation);
                log.Info(quotation.INVOICENO+ quotation.INVOICEUSER);
                return Ok(createdQuotation);
            }
            catch (Exception e)
            {
                log.Error(e+quotation.INVOICENO + quotation.INVOICEUSER);
                throw new HttpResponseException(
                                   Request.CreateErrorResponse(HttpStatusCode.NotFound, e.Message + "." + e.InnerException));
            }

        }
    }
}
