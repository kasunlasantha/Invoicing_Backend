using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using SLTInvoicingBackend.Core;
using SLTInvoicingBackend.Core.ApplicationServices;
using SLTInvoicingBackend.WebAPI.DTOs;
using AutoMapper;
using log4net;

namespace SLTInvoicingBackend.WebAPI.Controllers
{
    public class DefectgoodsController : ApiController
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        readonly IDefectgoodService _defectservice;
        IMapper _mapper;

        public DefectgoodsController(IDefectgoodService defectservice, IMapper mapper)
        {
            _defectservice = defectservice;
            _mapper = mapper;
        }

        [HttpPost]
        [ActionName("getDefectNo")]
        [ResponseType(typeof(string))]
        public IHttpActionResult getDefectNo([FromBody]CommonInfoDTO rrData)
        {
            try
            {
                var defNo = _defectservice.GetDefectRecNo(rrData.BC_CODE, rrData.CA_ID, rrData.CA_SERVICEID);
                log.Info(rrData.BC_CODE+ rrData.CA_SERVICEID);
                return Ok(defNo);
            }
            catch (Exception e)
            {
                log.Error(rrData.BC_CODE + rrData.CA_SERVICEID);
                throw new HttpResponseException(
                                   Request.CreateErrorResponse(HttpStatusCode.NotFound, e.Message + "." + e.InnerException));
            }

        }

        [HttpPost]
        [ActionName("getInvoices")]
        [ResponseType(typeof(INVOICEHEADER))]
        public IHttpActionResult getInvoices([FromBody]string centerCode) //[FromBody]string code
        {
            try
            {

                var Invo = _defectservice.GetAllInvoices(centerCode);
                // var mapInvo = _mapper.Map<InvoiceDTO>(Invo);
                return Ok(Invo);
            }
            catch (Exception e)
            {
                log.Error(e);
                throw new HttpResponseException(
                                   Request.CreateErrorResponse(HttpStatusCode.NotFound, e.Message + "." + e.InnerException));
            }

        }

        [HttpPost]
        [ActionName("insertDefectGoods")]
        [ResponseType(typeof(Boolean))]
        public IHttpActionResult insertDefectGoods([FromBody]DefectGoodDTO dfGood)
        {
            try
            {
                var mapDfGood = _mapper.Map<DEFECTGOOD>(dfGood);
                var insertedDfGood = _defectservice.CREATE(mapDfGood);
                log.Info(dfGood.BCCODE + dfGood.STRUSER);
                return Ok(insertedDfGood);
            }
            catch (Exception e)
            {
                log.Error(e + dfGood.BCCODE + dfGood.STRUSER);
                throw new HttpResponseException(
                                   Request.CreateErrorResponse(HttpStatusCode.NotFound, e.Message + "." + e.InnerException));
            }

        }
    }
}
