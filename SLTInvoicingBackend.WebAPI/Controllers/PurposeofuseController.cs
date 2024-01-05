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
    public class PurposeofuseController : ApiController
    {
        readonly IPurposeofuseService _purposeService;
        IMapper _mapper;
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public PurposeofuseController(IPurposeofuseService purposeService, IMapper mapper)
        {
            _purposeService = purposeService;
            _mapper = mapper;
        }

        [HttpPost]
        [ActionName("getPurposeofusBytransid")]
        [ResponseType(typeof(List<PurposeofUseDTO>))]
        public IHttpActionResult getPurposeofusBytransid([FromBody]int id)
        {
            try
            {
                var purposelist = _purposeService.GetPurposeofuseBytrantype(id);
                var mapPurposeList = _mapper.Map<IList<PurposeofUseDTO>>(purposelist);
                return Ok(mapPurposeList);
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
