using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using log4net;
using SLTInvoicingBackend.Core;
using SLTInvoicingBackend.Core.ApplicationServices;

namespace SLTInvoicingBackend.WebAPI.Controllers
{
    public class BillingcenterController : ApiController
    {
        readonly IBillingcenterService _billingcenterService;
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public BillingcenterController(IBillingcenterService billingcenterService)
        {
            _billingcenterService = billingcenterService;
        }

        [HttpPost]
        [ActionName("getBillingcenterNo")]
        [ResponseType(typeof(string[]))]
        public IHttpActionResult getBillingcenterNo()
        {
            try
            {
                var bilcnCodes = _billingcenterService.GetBillingcenterNo();
                log.Info("getBillingcenterNo ");
                return Ok(bilcnCodes);
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
