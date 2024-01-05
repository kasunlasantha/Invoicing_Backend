using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Cors;
using System.Web.Http.Filters;

namespace SLTInvoicingBackend.WebAPI.App_Start
{
   
    public class ValidateModelStateFilter : ActionFilterAttribute
    {
        //The method responds with Bad Request HttpStatus Code with the
        //Model state validation errors
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            var modelState = actionContext.ModelState;
            //var headers = actionContext.Request.Headers;
            //X509Certificate2 cert = actionContext.Request.GetClientCertificate();

            //if (headers.Contains("serial"))
            //{
            //    string _serial = headers.GetValues("serial").First();

            //    if (cert == null)
            //    {
            //        actionContext.Response = actionContext.Request
            //            .CreateErrorResponse(HttpStatusCode.BadRequest, "Backend :Client Certificate is Required");
            //        return;
            //    }


            //    if (_serial != cert.SerialNumber && _serial != "-")
            //    {
            //        actionContext.Response = actionContext.Request
            //           .CreateErrorResponse(HttpStatusCode.BadRequest, "Backend :Token is invalid");
            //        return;
            //    }

            //}
            //else
            //{
            //    actionContext.Response = actionContext.Request
            //            .CreateErrorResponse(HttpStatusCode.BadRequest, "Backend :Request serial is required");
            //    return;
            //}


            if (!modelState.IsValid)
                actionContext.Response = actionContext.Request
                     .CreateErrorResponse(HttpStatusCode.BadRequest, modelState);
        }
    }
}