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
    public class TranscationTypeController : ApiController
    {
        readonly ITransactionTypeService _tranService;
        IMapper _mapper;
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public TranscationTypeController(ITransactionTypeService transService, IMapper mapper)
        {
            _tranService = transService;
            _mapper = mapper;
        }

        [HttpPost]
        [ActionName("getAllTransactionType")]
        [ResponseType(typeof(List<TransactionTypeDTO>))]
        public IHttpActionResult getAllTransactionType()
        {
            try
            {
                var tarnsType = _tranService.GetAllTransactionType();
                var tarnsTypeList = _mapper.Map<IList<TransactionTypeDTO>>(tarnsType);
                return Ok(tarnsTypeList);
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
