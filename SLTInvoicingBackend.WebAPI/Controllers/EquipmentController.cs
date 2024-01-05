using AutoMapper;
using log4net;
using SLTInvoicingBackend.Core;
using SLTInvoicingBackend.Core.ApplicationServices;
using SLTInvoicingBackend.Core.DomainServices.Filtering;
using SLTInvoicingBackend.WebAPI.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;

namespace SLTInvoicingBackend.WebAPI.Controllers
{
    //[EnableCors(origins: "*", headers: "*", methods: "*")]
    public class EquipmentController : ApiController
    {
        readonly IEquipmentService _equiservice;
        IMapper _mapper;
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public EquipmentController(IEquipmentService equiservice, IMapper mapper)
        {
            _equiservice = equiservice;
            _mapper = mapper;
        }

        [HttpPost]
        [ActionName("getAllEquipment")]
        [ResponseType(typeof(FilteredList <EquipmentDTO>))]
        public IHttpActionResult getAllEquipment()
        {
            try
            {
                var allEqu = _equiservice.ReadAll();
                var newList = new List<EquipmentDTO>();
                foreach (var equipment in allEqu.List)
                {
                    var addlist = _mapper.Map<EquipmentDTO>(equipment);
                    newList.Add(addlist);

                }
                var newFilteredList = new FilteredList<EquipmentDTO>();
                newFilteredList.List = newList;
                newFilteredList.Count = allEqu.Count;
                return Ok(newFilteredList);
            }
            catch (Exception e)
            {
                log.Error(e);
                throw new HttpResponseException(
                                   Request.CreateErrorResponse(HttpStatusCode.NotFound, e.Message + "." + e.InnerException));
            }

        }

        [HttpPost]
        [ActionName("getEquipmentbyCode")]
        [ResponseType(typeof(EquipmentDTO))]
        public IHttpActionResult getEquipmentbyCode([FromBody]string code)
        {
            try
            {
                var Equ = _equiservice.ReadyByCode(code);
                var mapEqu= _mapper.Map<EquipmentDTO>(Equ);
                return Ok(mapEqu);
            }
            catch (Exception e)
            {
                log.Error(e);
                throw new HttpResponseException(
                                   Request.CreateErrorResponse(HttpStatusCode.NotFound, e.Message + "." + e.InnerException));
            }

        }


        [HttpPost]
        [ActionName("getEquipmentbyCenter")]
        [ResponseType(typeof(List<EquipmentDTO>))]
        public IHttpActionResult getEquipmentbyCenter([FromBody]string code)
        {
            try
            {
                
                var Equ = _equiservice.ReadyByCenter(code);              
                var equList=_mapper.Map<IList<EquipmentDTO>> (Equ);
                return Ok(equList);
            }
            catch (Exception e)
            {
                log.Error(e);
                throw new HttpResponseException(
                                   Request.CreateErrorResponse(HttpStatusCode.NotFound, e.Message + "." + e.InnerException));
            }

        }

        [HttpPost]
        [ActionName("getEquipmentbyCenter2")]
        [ResponseType(typeof(List<EquipmentDTO>))]
        public IHttpActionResult getEquipmentbyCenter2([FromBody]string code)
        {
            try
            {

                var Equ = _equiservice.ReadyByCenter2(code);
                var equList = _mapper.Map<IList<EquipmentDTO>>(Equ);
                return Ok(equList);
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
