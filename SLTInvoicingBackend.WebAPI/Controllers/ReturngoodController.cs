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
    public class ReturngoodController : ApiController
    {
        readonly IReturngoodService _returnservice;
        IMapper _mapper;
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public ReturngoodController(IReturngoodService returnservice, IMapper mapper)
        {
            _returnservice = returnservice;
            _mapper = mapper;
        }

        [HttpPost]
        [ActionName("getReturnNo")]
        [ResponseType(typeof(string))]
        public IHttpActionResult getReturnNoByCenterCode([FromBody]CommonInfoDTO rrData)
        {
            try
            {
                var retNo = _returnservice.GetReturnNo(rrData.BC_CODE, rrData.CA_ID, rrData.CA_SERVICEID);
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
        [ActionName("insertReturnGoods")]
        [ResponseType(typeof(Boolean))]
        public IHttpActionResult insertReturnGoods([FromBody]ReturngdDTO rtGood)
        {
            try
            {
                var mapRtGood = _mapper.Map<RETURNGOOD>(rtGood);
                var insertedRtGood = _returnservice.CREATE(mapRtGood);
                log.Info(rtGood.CENTERCODE+ rtGood.INVOICENO);
                return Ok(insertedRtGood);
            }
            catch (Exception e)
            {
                log.Error(e+ rtGood.INVOICENO);
                throw new HttpResponseException(
                                   Request.CreateErrorResponse(HttpStatusCode.NotFound, e.Message + "." + e.InnerException));
            }

        }

        [HttpPost]
        [ActionName("getReturngoodsbyCenter")]
        [ResponseType(typeof(List<ReturngdDTO>))]
        public IHttpActionResult getReturngoodsbyCenter([FromBody]string centerCode) //[FromBody]string code
        {
            try
            {

                var Retgd = _returnservice.GetAllReturngood(centerCode);
                var mapRetgd = _mapper.Map<IList<ReturngdDTO>>(Retgd);
                return Ok(mapRetgd);
            }
            catch (Exception e)
            {
                log.Error(e);
                throw new HttpResponseException(
                                   Request.CreateErrorResponse(HttpStatusCode.NotFound, e.Message + "." + e.InnerException));
            }

        }

        [HttpPost]
        [ActionName("getReturnAmount")]
        [ResponseType(typeof(decimal))]
        public IHttpActionResult getReturnAmount([FromBody]string retNo) //[FromBody]string code
        {
            try
            {

                var Retgd = _returnservice.getReturnAmount(retNo);
                return Ok(Retgd);
            }
            catch (Exception e)
            {
                log.Error(e);
                throw new HttpResponseException(
                                   Request.CreateErrorResponse(HttpStatusCode.NotFound, e.Message + "." + e.InnerException));
            }

        }

        [HttpPost]
        [ResponseType(typeof(List<ReturngdDTO>))]
        [ActionName("getReturnGoodsDetails")]
        public IHttpActionResult getReturnGoodsDetails([FromBody]RPTReturnGoodsDTO returndto)
        {
            try
            {

                var dtRet = _returnservice.getReturnGoodsRPT(returndto.DATEFROM, returndto.DATETO, returndto.BCENTERNAME, returndto.ACTIONNAME);
                return Ok(dtRet);
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
