using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SLTInvoicingBackend.Core.ApplicationServices;
using AutoMapper;
using System.Web.Http.Description;
using SLTInvoicingBackend.WebAPI.DTOs;
using SLTInvoicingBackend.Core;
using CrystalDecisions.CrystalReports.Engine;
using System.IO;
using CrystalDecisions.Shared;
using System.Web;
using log4net;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace SLTInvoicingBackend.WebAPI.Controllers
{
    public class InvoiceController : ApiController
    {

        readonly IInvoiceService _invoservice;
        IMapper _mapper;
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public InvoiceController(IInvoiceService invoservice, IMapper mapper)
        {
            _invoservice = invoservice;
            _mapper = mapper;
        }

        [HttpPost]
        [ActionName("getInvoicesbyId")]
        [ResponseType(typeof(INVOICEHEADER))]
        public IHttpActionResult getInvoicesbyId([FromBody]string id)
        {
            try
            {

                var Invo = _invoservice.GetInvoiceById(id);
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
        [ActionName("createInvoice")]
        [ResponseType(typeof(InvoicehdDTO))]
        public IHttpActionResult createInvoice([FromBody]InvoicehdDTO order)
        {
            try
            {
                var mapOrder = _mapper.Map<INVOICEHEADER>(order);
                var createdInvo = _invoservice.CREATE(mapOrder);
                Task.Run(() => log.Info(order.BCCODE + order.INVOICEUSER));
                return Ok(createdInvo);
            }
            catch (Exception e)
            {
                log.Error(e.ToString()+ order.BCCODE + order.INVOICEUSER+ JsonConvert.SerializeObject(order, Formatting.Indented));
                throw new HttpResponseException(
                                   Request.CreateErrorResponse(HttpStatusCode.NotFound, e.Message + "." + e.InnerException));
            }

        }


        [HttpPost]
        [ActionName("getInvoiceno")]
        public IHttpActionResult getInvoiceno([FromBody]CommonInfoDTO info)
        {
            try
            {

                var createdInvo = _invoservice.GenerateInvoiceNo(info.BC_CODE, info.CA_SERVICEID, info.CA_ID);

                return Ok(createdInvo);
            }
            catch (Exception e)
            {
                log.Error(e.ToString());
                throw new HttpResponseException(
                                   Request.CreateErrorResponse(HttpStatusCode.NotFound, e.Message + "." + e.InnerException));
            }

        }

        [HttpPost]
        [ActionName("getInvoicesbyCenter")]
        [ResponseType(typeof(List<InvoicehdDTO>))]
        public IHttpActionResult getInvoicesbyCenter([FromBody]string centerCode)
        {
            try
            {

                var Invo = _invoservice.GetAllInvoicesByCenter(centerCode);
                var mapInvo = _mapper.Map<IList<InvoicehdDTO>>(Invo);
                return Ok(mapInvo);
            }
            catch (Exception e)
            {
                log.Error(e);
                throw new HttpResponseException(
                                   Request.CreateErrorResponse(HttpStatusCode.NotFound, e.Message + "." + e.InnerException));
            }

        }

        [HttpPost]
        [ActionName("getInvoicesbyCenter2")]
        [ResponseType(typeof(List<InvoicehdDTO>))]
        public IHttpActionResult getInvoicesbyCenter2([FromBody]string centerCode)
        {
            try
            {

                var Invo = _invoservice.GetAllInvoicesByCenter2(centerCode);
                var mapInvo = _mapper.Map<IList<InvoicehdDTO>>(Invo);
                return Ok(mapInvo);
            }
            catch (Exception e)
            {
                log.Error(e);
                throw new HttpResponseException(
                                   Request.CreateErrorResponse(HttpStatusCode.NotFound, e.Message + "." + e.InnerException));
            }

        }


        [HttpPost]
        [ActionName("getInvoiceTaxNo")]
        public IHttpActionResult getInvoiceTaxNo([FromBody]string center)
        {
            try
            {

                var createdInvTaxNo = _invoservice.GenerateInvoiceTaxNo(center);
                return Ok(createdInvTaxNo);
            }
            catch (Exception e)
            {
                log.Error(e);
                throw new HttpResponseException(
                                   Request.CreateErrorResponse(HttpStatusCode.NotFound, e.Message + "." + e.InnerException));
            }

        }


        [HttpPost]
        [ActionName("getRejectInvoicesbyCenter")]
        [ResponseType(typeof(List<InvoicehdDTO>))]
        public IHttpActionResult getRejectInvoicesbyCenter([FromBody]string centerCode)
        {
            try
            {

                var Invo = _invoservice.getRjctdInvoicesbyCenter(centerCode);
                var mapInvo = _mapper.Map<IList<INVOICEHEADER>>(Invo);
                return Ok(mapInvo);
            }
            catch (Exception e)
            {
                log.Error(e);
                throw new HttpResponseException(
                                   Request.CreateErrorResponse(HttpStatusCode.NotFound, e.Message + "." + e.InnerException));
            }

        }

        [HttpPost]
        [ActionName("updateRejectInvoice")]
        [ResponseType(typeof(InvoicehdDTO))]
        public IHttpActionResult updateRejectInvoice([FromBody]InvoicehdDTO order)
        {
            try
            {
                var mapOrder = _mapper.Map<INVOICEHEADER>(order);
                var createdInvo = _invoservice.UpdateRejectInvoice(mapOrder);
                log.Info(order.BCCODE+order.INVOICEUSER);
                return Ok(createdInvo);
            }
            catch (Exception e)
            {
                log.Error(e+ order.BCCODE + order.INVOICEUSER);
                throw new HttpResponseException(
                                   Request.CreateErrorResponse(HttpStatusCode.NotFound, e.Message + "." + e.InnerException));
            }

        }

        [HttpPost]
        [ActionName("cancelInvoice")]
        public IHttpActionResult cancelInvoice([FromBody]CommonInfoDTO comdto)
        {
            ReportDocument rd = null;
            MemoryStream ms = null;
            Stream stream = null;

            try
            {        
                var cancelledInvo = _invoservice.CANCEL(comdto.INVOICENO, comdto.CA_SERVICEID);
                //var dtInvo = _invoservice.GetRptInvcoice(comdto.INVOICENO);
                using (rd = new ReportDocument())
                {
                    string rptname = "CRCancleInvoiceRPT.rpt";
                    string strRptPath = System.Web.HttpContext.Current.Server.MapPath("~/") + "Reports//" + rptname;
                    rd.Load(strRptPath);
                    rd.DataSourceConnections.Clear();
                    rd.SetDataSource(cancelledInvo.Tables[0]);


                    //rd.ExportToHttpResponse(ExportFormatType.PortableDocFormat, System.Web.HttpContext.Current.Response, false, "crReport");

                    stream = rd.ExportToStream(ExportFormatType.PortableDocFormat);
                    ms = new MemoryStream();
                    stream.CopyTo(ms);
                    var response = HttpContext.Current.Response;
                    response.Clear();
                    response.Buffer = false;
                    response.ClearContent();
                    response.ClearHeaders();
                    response.Cache.SetCacheability(HttpCacheability.Public);
                    response.ContentType = "application/pdf";
                    response.Headers.Set("Access-Control-Allow-Origin", "*");
                    ms.WriteTo(response.OutputStream);
                    log.Info(comdto.INVOICENO+ comdto.CA_SERVICEID);
                    return Ok(response);

                  
                }
            }
            catch (Exception e)
            {
                log.Error(e+ comdto.INVOICENO + comdto.CA_SERVICEID);
                throw new HttpResponseException(
                                   Request.CreateErrorResponse(HttpStatusCode.NotFound, e.Message + "." + e.InnerException));
            }
            finally { ms = null; stream = null; rd = null; }

        }

        [HttpPost]
        [ResponseType(typeof(List<ItemSalesDTO>))]
        [ActionName("getItemSalesDetails")]
        public IHttpActionResult getItemSalesDetails([FromBody]RPTItemSalesDTO rtpItemSales)
        {
            try
            {

                var itemcode = "";
                var reciptstat = "";
                if (rtpItemSales.ITEMCODE == "" || rtpItemSales.ITEMCODE == null)
                {
                    itemcode = "%";
                }
                else
                {
                    itemcode = rtpItemSales.ITEMCODE;
                }

                if (rtpItemSales.RECEIPTSTAT == true)
                {
                    reciptstat = "%";
                }
                if (rtpItemSales.RECEIPTSTAT == false)
                {
                    reciptstat = "1";
                }

                var dtRet = _invoservice.getItemSalesRPT(rtpItemSales.DATEFROM, rtpItemSales.DATETO, reciptstat, itemcode, rtpItemSales.BCENTERNAME);
                //var mapItmSale = _mapper.Map<IList<ItemSalesDTO>>(dtRet);
                return Ok(dtRet);

            }
            catch (Exception e)
            {
                log.Error(e);
                throw new HttpResponseException(
                                   Request.CreateErrorResponse(HttpStatusCode.NotFound, e.Message + "." + e.InnerException));
            }
        }

        [HttpPost]
        [ResponseType(typeof(List<InvoicehdDTO>))]
        [ActionName("getInvoiceDetails")]
        public IHttpActionResult getInvoiceDetails([FromBody]RPTInvoiceDetailsDTO invoicdatailedto)
        {
            string IsTax = "";
            string Tax = "";
            string status = "";
            string CancelStat = "0";
            string reciptst = "%";
            try
            {
                if (invoicdatailedto.TAXTYPE == "0")
                {
                    IsTax = "%";
                    Tax = "Tax/Non Tax/Tax Exempted ";
                }
                if (invoicdatailedto.TAXTYPE == "1")
                {
                    //IsTax = "0";
                    IsTax = "1";
                    //Tax = invoicdatailedto.TAXTYPE;
                    Tax = "Non Tax Invoice";

                }
                if (invoicdatailedto.TAXTYPE == "2")
                {
                    //IsTax = "1";
                    IsTax = "2";
                    //Tax = invoicdatailedto.TAXTYPE;
                    Tax = "Tax Invoice";
                }
                if (invoicdatailedto.TAXTYPE == "3")
                {
                    //IsTax = "2";
                    IsTax = "3";
                    //Tax = invoicdatailedto.TAXTYPE;
                    Tax = "Tax Excempted";
                }


                if (invoicdatailedto.STATUS == "ACTIVE")
                {
                    status = "All Active Invoices";
                    CancelStat = "0";
                    reciptst = "%";
                }
                if (invoicdatailedto.STATUS == "PAIDACTIVEONLY")
                {
                    status = "Active / Receipt";
                    reciptst = "1";
                    CancelStat = "0";
                }
                if (invoicdatailedto.STATUS == "NPAIDACTIVEONLY")
                {
                    status = "Cancel / Receipt";
                    reciptst = "0";
                    CancelStat = "0";
                }
                if (invoicdatailedto.STATUS == "0")  //---if inactive check box is clicked => take INACTIVE( CANCELED ) dropdown INDEX VALUE as "0"
                {
                    status = "All Cancel Invoices";
                    CancelStat = "1";
                    reciptst = "%";
                }
                if (invoicdatailedto.STATUS == "1")  //---if inactive check box is clicked => take INACTIVE( CANCELED ) dropdown INDEX VALUE as "1"
                {
                    status = "All Cancel Invoices";
                    CancelStat = "1";
                    reciptst = "0";
                }
                if (invoicdatailedto.STATUS == "2")  //---if inactive check box is clicked => take INACTIVE( CANCELED ) dropdown INDEX VALUE as "2"
                {
                    status = "All Cancel Invoices";
                    CancelStat = "1";
                    reciptst = "1";
                }


                // MM/dd/yyyy
                var dtRet = _invoservice.getInvoiceDetailsRPT(invoicdatailedto.DATEFROM, invoicdatailedto.DATETO, invoicdatailedto.BCENTERNAME, IsTax, reciptst, CancelStat);
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
