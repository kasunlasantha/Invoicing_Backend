using AutoMapper;
using log4net;
using Newtonsoft.Json;
using SLTInvoicingBackend.Core;
using SLTInvoicingBackend.Core.ApplicationServices;
using SLTInvoicingBackend.WebAPI.App_Start;
using SLTInvoicingBackend.WebAPI.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using BC = BCrypt.Net.BCrypt;

namespace SLTInvoicingBackend.WebAPI.Controllers
{
    //[CustomExceptionFilter]
   
    public class CashierController : ApiController
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        readonly ICashierService _cshiservice;
        IMapper _mapper;
        public CashierController(ICashierService cshiservice, IMapper mapper)
        {
            _cshiservice = cshiservice;
            _mapper = mapper;
        }

        // POST api/Cashier
        [HttpPost]
        [ActionName("Login")]
        [ResponseType(typeof(UserDTO))]
        public IHttpActionResult Login([FromBody]LoginDTO model)
        {
            string serial = null;
            try
            {
                //serial = cert.SerialNumber; //"0160ED8D358F"
                var cashi = _mapper.Map<CASHIER>(model);
                cashi.CERTIFICATESERIAL = serial;
                var cashiout = _cshiservice.SignIn(cashi);
                var outuserDTO = _mapper.Map<UserDTO>(cashiout);
                log.Info(model.CA_SERVICEID + " : " + model.BC_CODE);

                return Ok(outuserDTO);

            }
            catch (Exception er)
            {
                model.CA_PASSWORD= BC.HashPassword(model.CA_PASSWORD, BC.GenerateSalt(12));
                log.Error(er.ToString()+" Login " + model.CA_SERVICEID+ JsonConvert.SerializeObject(model, Formatting.Indented));
                throw new HttpResponseException(
                    Request.CreateErrorResponse(HttpStatusCode.NotFound, er.Message + "." + er.InnerException));
            }

        }


        [HttpPost]
        [ActionName("LoginOff")]
        public bool LoginOff([FromBody]int cashierID)
        {
            
            try
            {
                var cashioff = _cshiservice.SignOff(cashierID);
                log.Info(cashierID.ToString());
                return cashioff;
            }
            catch (Exception e)
            {
                log.Error(e + " Login " + cashierID.ToString());
                throw new HttpResponseException(
                                   Request.CreateErrorResponse(HttpStatusCode.NotFound, e.Message + "." + e.InnerException));
            }
           
        }

    }
}
