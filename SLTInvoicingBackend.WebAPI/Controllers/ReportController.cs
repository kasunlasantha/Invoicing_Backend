using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using log4net;
using SLTInvoicingBackend.Core.ApplicationServices;
using SLTInvoicingBackend.Core.Entities;
using SLTInvoicingBackend.WebAPI.DTOs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;


namespace SLTInvoicingBackend.WebAPI.Controllers
{
    //[EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ReportController : ApiController
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        readonly IInvoiceService _invoservice;
        readonly IReturngoodService _returnservice;
        readonly IDefectgoodService _defectgoodService;
        readonly IGRNDataService _igrndataService;
        readonly IQuotationService _quotationService;
        readonly IStockService _stockService;

        public ReportController(IInvoiceService invoservice, IReturngoodService returnservice, IDefectgoodService defectgoodService, IGRNDataService igrndataService, IQuotationService quotationService, IStockService stockService)
        {
            _invoservice = invoservice;
            _returnservice = returnservice;
            _defectgoodService = defectgoodService;
            _igrndataService = igrndataService;
            _quotationService = quotationService;
            _stockService = stockService;
        }


        [HttpPost]
        [ActionName("getInvoiceRPT")]
        // [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IHttpActionResult getInvoiceRPT([FromBody]string invno)
        {
            ReportDocument rd = null;
            MemoryStream ms = null;
            Stream stream = null;
            try
            {

                var dtInvo = _invoservice.GetRptInvcoice(invno);
                using (rd = new ReportDocument())
                {
                    string rptname = "CRInvoiceTaxRPT.rpt";
                    string strRptPath = System.Web.HttpContext.Current.Server.MapPath("~/") + "Reports//" + rptname;
                    rd.Load(strRptPath);
                    rd.DataSourceConnections.Clear();
                    rd.SetDataSource(dtInvo.Tables[0]);
                    rd.Subreports[0].DataSourceConnections.Clear();
                    rd.Subreports[0].SetDataSource(dtInvo.Tables[1]);



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
                    log.Info(invno);
                    return Ok(response);

                }

            }
            catch (Exception e)
            {
                log.Error(e+ invno);
                throw new HttpResponseException(
                                   Request.CreateErrorResponse(HttpStatusCode.NotFound, e.Message + "." + e.InnerException));
            }
            finally { ms = null; stream = null; rd = null; }
        }


        [HttpPost]
        [ActionName("getReturnNoteRPT")]
        // [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IHttpActionResult getReturnNoteRPT([FromBody]string retno)
        {
            ReportDocument rd = null;
            MemoryStream ms = null;
            Stream stream = null;
            try
            {

                var dtRet = _returnservice.GetRptReturngood(retno);
                using (rd = new ReportDocument())
                {
                    string rptname = "CRReturnNoteRPT.rpt";
                    string strRptPath = System.Web.HttpContext.Current.Server.MapPath("~/") + "Reports//" + rptname;
                    rd.Load(strRptPath);
                    rd.DataSourceConnections.Clear();
                    rd.SetDataSource(dtRet);

                    //rd.SetParameterValue("CenterName", "CFTS");
                    //rd.SetParameterValue("AccCode", model.ACCODE);
                    rd.SetParameterValue("Temp", "Temp");
                    rd.SetParameterValue("Balance", "Balance");
                    rd.SetParameterValue("BalanceValue", 123);
                    //rd.SetParameterValue("lblcashier", "lblcashier");

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
                    return Ok(response);

                }

            }
            catch (Exception e)
            {
                log.Error(e + retno);
                throw new HttpResponseException(
                                   Request.CreateErrorResponse(HttpStatusCode.NotFound, e.Message + "." + e.InnerException));
            }
            finally { ms = null; stream = null; rd = null; }
        }

        [HttpPost]
        [ActionName("getDefectSummaryRPT")]
        // [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IHttpActionResult getDefectSummaryRPT([FromBody]ReportDTO defectdto)
        {   // 01/15/2010
            ReportDocument rd = null;
            MemoryStream ms = null;
            Stream stream = null;
            try
            {
                var dtRet = _defectgoodService.getDefectSummaryRPT(defectdto.DATEFROM, defectdto.DATETO, defectdto.BCENTERNAME);

                using (rd = new ReportDocument())
                {
                    string rptname = "CRDefectSummaryReport.rpt";
                    string strRptPath = System.Web.HttpContext.Current.Server.MapPath("~/") + "Reports//" + rptname;
                    rd.Load(strRptPath);
                    rd.DataSourceConnections.Clear();
                    rd.SetDataSource(dtRet);

                    rd.SetParameterValue("FromDate", defectdto.DATEFROM);
                    rd.SetParameterValue("ToDate", defectdto.DATETO);

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
                    return Ok(response);

                }

            }
            catch (Exception e)
            {
                log.Error(e + defectdto.BCENTERNAME);
                throw new HttpResponseException(
                                   Request.CreateErrorResponse(HttpStatusCode.NotFound, e.Message + "." + e.InnerException));
            }
            finally { ms = null; stream = null; rd = null; }
        }

        [HttpPost]
        [ActionName("getDiscountedSalesRPT")]
        // [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IHttpActionResult getDiscountedSalesRPT([FromBody]ReportDTO defectdto)
        {   // 01/15/2010
            ReportDocument rd = null;
            MemoryStream ms = null;
            Stream stream = null;
            List<RPTDISCOUNTEDSALES> dtRet = new List<RPTDISCOUNTEDSALES>();
            try
            {
                // MM/dd/yyyy
                dtRet = _invoservice.getDiscountedSalesRPT(defectdto.DATEFROM, defectdto.DATETO, defectdto.BCENTERNAME);

                using (rd = new ReportDocument())
                {
                    string rptname = "CRSalesDiscountReport.rpt";
                    string strRptPath = System.Web.HttpContext.Current.Server.MapPath("~/") + "Reports//" + rptname;
                    rd.Load(strRptPath);
                    rd.DataSourceConnections.Clear();
                    rd.SetDataSource(dtRet);

                    rd.SetParameterValue("FromDate", defectdto.DATEFROM);
                    rd.SetParameterValue("ToDate", defectdto.DATETO);

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
                    return Ok(response);

                }

            }
            catch (Exception e)
            {
                if (dtRet.Count != 0)
                {
                    log.Error(e);
                    throw new HttpResponseException(
                                       Request.CreateErrorResponse(HttpStatusCode.NotFound, e.Message + "." + e.InnerException));
                }
                else
                {
                    log.Error(e);
                    throw new HttpResponseException(
                                       Request.CreateErrorResponse(HttpStatusCode.NotFound, e.Message + " Table is empty !."));

                }
            }
            finally { ms = null; stream = null; rd = null; dtRet = null; }
        }


        [HttpPost]
        [ActionName("getInvoiceSummaryRPT")]
        // [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IHttpActionResult getInvoiceSummaryRPT([FromBody]ReportDTO defectdto)
        {   // 01/15/2010
            ReportDocument rd = null;
            MemoryStream ms = null;
            Stream stream = null;
            try
            {
                // MM/dd/yyyy
                var dtRet = _invoservice.getInvoiceSummaryRPT(defectdto.DATEFROM, defectdto.DATETO, defectdto.BCENTERNAME);

                using (rd = new ReportDocument())
                {
                    string rptname = "CRInvoiceSummaryReport.rpt";
                    string strRptPath = System.Web.HttpContext.Current.Server.MapPath("~/") + "Reports//" + rptname;
                    rd.Load(strRptPath);
                    rd.DataSourceConnections.Clear();
                    rd.SetDataSource(dtRet);

                    rd.SetParameterValue("FromDate", defectdto.DATEFROM);
                    rd.SetParameterValue("ToDate", defectdto.DATETO);

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
                    return Ok(response);

                }

            }
            catch (Exception e)
            {
                log.Error(e);
                throw new HttpResponseException(
                                   Request.CreateErrorResponse(HttpStatusCode.NotFound, e.Message + "." + e.InnerException));
            }
            finally { ms = null; stream = null; rd = null; }
        }

        [HttpPost]
        [ActionName("getCancelInvoiceRPT")]
        // [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IHttpActionResult getCancelInvoiceRPT([FromBody]string invno)
        {
            ReportDocument rd = null;
            MemoryStream ms = null;
            Stream stream = null;
            try
            {

                var dtInvo = _invoservice.GetRptInvcoice(invno);
                using (rd = new ReportDocument())
                {
                    string rptname = "CRCancleInvoiceRPT.rpt";
                    string strRptPath = System.Web.HttpContext.Current.Server.MapPath("~/") + "Reports//" + rptname;
                    rd.Load(strRptPath);
                    rd.DataSourceConnections.Clear();
                    rd.SetDataSource(dtInvo.Tables[0]);


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
                    return Ok(response);

                }

            }
            catch (Exception e)
            {

                log.Error(e);
                throw new HttpResponseException(
                                   Request.CreateErrorResponse(HttpStatusCode.NotFound, e.Message + "." + e.InnerException));
            }
            finally { ms = null; stream = null; rd = null; }
        }

        [HttpPost]
        [ActionName("getDefectReturnRPT")]
        // [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IHttpActionResult getDefectReturnRPT([FromBody]string defno)
        {
            ReportDocument rd = null;
            MemoryStream ms = null;
            Stream stream = null;
            try
            {

                var dtRet = _defectgoodService.GetRptDefectgood(defno);
                using (rd = new ReportDocument())
                {
                    string rptname = "CRDefectReturnRPT.rpt";
                    string strRptPath = System.Web.HttpContext.Current.Server.MapPath("~/") + "Reports//" + rptname;
                    rd.Load(strRptPath);
                    rd.DataSourceConnections.Clear();
                    rd.SetDataSource(dtRet);

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
                    return Ok(response);

                }

            }
            catch (Exception e)
            {

                log.Error(e);
                throw new HttpResponseException(
                                   Request.CreateErrorResponse(HttpStatusCode.NotFound, e.Message + "." + e.InnerException));
            }
            finally { ms = null; stream = null; rd = null; }
        }

        [HttpPost]
        [ActionName("getReturnSummaryRPT")]
        // [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IHttpActionResult getReturnSummaryRPT([FromBody]ReportDTO defectdto)
        {   // 01/15/2010           
            ReportDocument rd = null;
            MemoryStream ms = null;
            Stream stream = null;

            try
            {

                    var dtRet = _returnservice.getReturnSummaryRPT(defectdto.DATEFROM, defectdto.DATETO, defectdto.BCENTERNAME);                    

                    using (rd = new ReportDocument())
                    {
                        string rptname = "CRReturnSummaryReport.rpt";
                        string strRptPath = System.Web.HttpContext.Current.Server.MapPath("~/") + "Reports//" + rptname;
                        rd.Load(strRptPath);
                        rd.DataSourceConnections.Clear();
                        rd.SetDataSource(dtRet);

                        rd.SetParameterValue("FromDate", defectdto.DATEFROM);
                        rd.SetParameterValue("ToDate", defectdto.DATETO);

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
                        return Ok(response);

                    }

            }
            catch (Exception e)
            {
                        log.Error(e);
                        throw new HttpResponseException(
                                           Request.CreateErrorResponse(HttpStatusCode.NotFound,  " Table is empty !." ));                
            }
            finally { ms = null; stream = null; rd = null; }
        }

        [HttpPost]
        [ActionName("getReturnGoodsRPT")] //No Data to Test
        // [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IHttpActionResult getReturnGoodsRPT([FromBody]RPTReturnGoodsDTO returndto)
        {
            string ActionName = "";
            ReportDocument rd = null;
            MemoryStream ms = null;
            Stream stream = null;

            List<RPTRETURNGOODS> dtRet = new List<RPTRETURNGOODS>();
            try
            {

                dtRet = _returnservice.getReturnGoodsRPT(returndto.DATEFROM, returndto.DATETO, returndto.BCENTERNAME, returndto.ACTIONNAME);

                using (rd = new ReportDocument())
                {
                    string rptname = "CRGoodsReturnReport.rpt";
                    string strRptPath = System.Web.HttpContext.Current.Server.MapPath("~/") + "Reports//" + rptname;
                    rd.Load(strRptPath);
                    rd.DataSourceConnections.Clear();
                    rd.SetDataSource(dtRet);

                    if (returndto.ACTIONNAME == "%")
                    {
                        ActionName = "All Action Types";
                    }
                    else if (returndto.ACTIONNAME == "9")
                    {
                        ActionName = "Issued Good Of Same Equipment";
                    }
                    else if (returndto.ACTIONNAME == "10")
                    {
                        ActionName = "Returned Cash";
                    }
                    else if (returndto.ACTIONNAME == "11")
                    {
                        ActionName = "Issued Item With Another Code";
                    }
                    rd.SetParameterValue("CName", returndto.BCENTERNAME);
                    rd.SetParameterValue("FromDate", returndto.DATEFROM);
                    rd.SetParameterValue("ToDate", returndto.DATETO);
                    rd.SetParameterValue("Action", ActionName);

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
                    return Ok(response);

                }

            }
            catch (Exception e)
            {
                if (dtRet.Count != 0)
                {
                    log.Error(e);
                    throw new HttpResponseException(
                                       Request.CreateErrorResponse(HttpStatusCode.NotFound, e.Message + "." + e.InnerException));
                }
                else
                {
                    log.Error(e);
                    throw new HttpResponseException(
                                       Request.CreateErrorResponse(HttpStatusCode.NotFound, " Table is empty !."));

                }

            }

            finally { ms = null; stream = null; rd = null; }
        }


        [HttpPost]
        [ActionName("getDefectGoodsRPT")] 
        // [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IHttpActionResult getDefectGoodsRPT([FromBody]ReportDTO defectdto)
        {   // 01/15/2010           
            ReportDocument rd = null;
            MemoryStream ms = null;
            Stream stream = null;
            try
            {

                var dtRet = _defectgoodService.getDefectGoodsRPT(defectdto.DATEFROM, defectdto.DATETO, defectdto.BCENTERNAME);

                using (rd = new ReportDocument())
                {
                    string rptname = "CRDefectGoodsReport.rpt";
                    string strRptPath = System.Web.HttpContext.Current.Server.MapPath("~/") + "Reports//" + rptname;
                    rd.Load(strRptPath);
                    rd.DataSourceConnections.Clear();
                    rd.SetDataSource(dtRet);

                    rd.SetParameterValue("CName", defectdto.BCENTERNAME);
                    rd.SetParameterValue("FromDate", defectdto.DATEFROM);
                    rd.SetParameterValue("ToDate", defectdto.DATETO);

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
                    return Ok(response);

                }

            }
            catch (Exception e)
            {
                log.Error(e);
                throw new HttpResponseException(
                                   Request.CreateErrorResponse(HttpStatusCode.NotFound, e.Message + "." + e.InnerException));
            }
            finally { ms = null; stream = null; rd = null; }
        }

        [HttpPost]
        [ActionName("getItemSalesRPT")]
        public IHttpActionResult getItemSalesRPT([FromBody]RPTItemSalesDTO rtpItemSales)
        {
            ReportDocument rd = null;
            MemoryStream ms = null;
            Stream stream = null;
            try
            {
                var Status = "";
                var RSt = "";
                var Itemcode = "";
                var reciptstat = "";

                if (rtpItemSales.ITEMCODE == "" || rtpItemSales.ITEMCODE == null)
                {
                    Itemcode = "%";
                    Status = "All Item Code";
                }
                else
                {
                    Itemcode = rtpItemSales.ITEMCODE;
                    Status = rtpItemSales.ITEMCODE;
                }
                if (rtpItemSales.RECEIPTSTAT == true)
                {
                    RSt = "Yes";
                    reciptstat = "%";
                }
                if (rtpItemSales.RECEIPTSTAT == false)
                {
                    RSt = "No";
                    reciptstat = "1";
                }

                var dtRet = _invoservice.getItemSalesRPT(rtpItemSales.DATEFROM, rtpItemSales.DATETO, reciptstat, Itemcode, rtpItemSales.BCENTERNAME);
                using (rd = new ReportDocument())
                {
                    string rptname = "CRItemSalesReport.rpt";
                    string strRptPath = System.Web.HttpContext.Current.Server.MapPath("~/") + "Reports//" + rptname;
                    rd.Load(strRptPath);
                    rd.DataSourceConnections.Clear();
                    rd.SetDataSource(dtRet);

                    rd.SetParameterValue("CName", rtpItemSales.BCENTERNAME);
                    rd.SetParameterValue("FromDate", rtpItemSales.DATEFROM);
                    rd.SetParameterValue("ToDate", rtpItemSales.DATETO);
                    rd.SetParameterValue("Status", Status);
                    rd.SetParameterValue("Recipt", RSt);

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
                    return Ok(response);

                }

            }
            catch (Exception e)
            {
                log.Error(e);
                throw new HttpResponseException(
                                   Request.CreateErrorResponse(HttpStatusCode.NotFound, e.Message + "." + e.InnerException));
            }
            finally { ms = null; stream = null; rd = null; }
        }

        [HttpPost]
        [ActionName("getGoodsReceivedNotesDetailsRPT")]
        // [EnableCors(origins: "*", headers: "*", methods: "*")]  
        public IHttpActionResult getGoodsReceivedNotesDetailsRPT([FromBody]ReportDTO returndto)
        {
            ReportDocument rd = null;
            MemoryStream ms = null;
            Stream stream = null;
            try
            {

                var dtRet = _igrndataService.getGoodsReceivedNotesDetailsRPT(returndto.DATEFROM, returndto.DATETO, returndto.BCENTERNAME);

                using (rd = new ReportDocument())
                {
                    string rptname = "CRGRNDetailsReport.rpt";
                    string strRptPath = System.Web.HttpContext.Current.Server.MapPath("~/") + "Reports//" + rptname;
                    rd.Load(strRptPath);
                    rd.DataSourceConnections.Clear();
                    rd.SetDataSource(dtRet);

                    rd.SetParameterValue("CName", returndto.BCENTERNAME);
                    rd.SetParameterValue("FromDate", returndto.DATEFROM);
                    rd.SetParameterValue("ToDate", returndto.DATETO);

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
                    return Ok(response);

                }

            }
            catch (Exception e)
            {
                log.Error(e);
                throw new HttpResponseException(
                                   Request.CreateErrorResponse(HttpStatusCode.NotFound, e.Message + "." + e.InnerException));
            }
            finally { ms = null; stream = null; rd = null; }
        }

        [HttpPost]
        [ActionName("getInvoiceDetailsRPT")] 
        // [EnableCors(origins: "*", headers: "*", methods: "*")]    
        public IHttpActionResult getInvoiceDetailsRPT([FromBody]RPTInvoiceDetailsDTO invoicdatailedto)// RPTInvoiceDetailsDTO
        {   // 01/15/2010
            ReportDocument rd = null;
            MemoryStream ms = null;
            Stream stream = null;
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

                
                if(invoicdatailedto.STATUS == "ACTIVE")
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


                 
                var dtRet = _invoservice.getInvoiceDetailsRPT(invoicdatailedto.DATEFROM, invoicdatailedto.DATETO, invoicdatailedto.BCENTERNAME, IsTax, reciptst, CancelStat);

                using (rd = new ReportDocument())
                {
                    string rptname = "CRInvoiceReport.rpt";
                    string strRptPath = System.Web.HttpContext.Current.Server.MapPath("~/") + "Reports//" + rptname;
                    rd.Load(strRptPath);
                    rd.DataSourceConnections.Clear();
                    rd.SetDataSource(dtRet);

                    rd.SetParameterValue("CName", invoicdatailedto.BCENTERNAME);
                    rd.SetParameterValue("Mode", invoicdatailedto.SELECTGOODS);
                    rd.SetParameterValue("status", status);
                    rd.SetParameterValue("Tax", Tax);

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
                    return Ok(response);

                }

            }
            catch (Exception e)
            {
                log.Error(e);
                throw new HttpResponseException(
                                   Request.CreateErrorResponse(HttpStatusCode.NotFound, e.Message + "." + e.InnerException));
            }
            finally { ms = null; stream = null; rd = null; }
        }

        [HttpPost]
        [ActionName("getQuotationRPT")]
        // [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IHttpActionResult getQuotationRPT([FromBody]string quotno)
        {
            ReportDocument rd = null;
            MemoryStream ms = null;
            Stream stream = null;
            try
            {

                var dtQuot = _quotationService.GetRptQuotation(quotno);
                using (rd = new ReportDocument())
                {
                    string rptname = "CRQuotationRPT.rpt";
                    string strRptPath = System.Web.HttpContext.Current.Server.MapPath("~/") + "Reports//" + rptname;
                    rd.Load(strRptPath);
                    rd.DataSourceConnections.Clear();
                    rd.SetDataSource(dtQuot);



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
                    return Ok(response);

                }

            }
            catch (Exception e)
            {
                log.Error(e);
                throw new HttpResponseException(
                                   Request.CreateErrorResponse(HttpStatusCode.NotFound, e.Message + "." + e.InnerException));
            }
            finally { ms = null; stream = null; rd = null; }
        }

        [HttpPost]
        [ActionName("getCurrentStocklevelRPT")]
        // [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IHttpActionResult getCurrentStocklevelRPT([FromBody]string centerno)
        {
            ReportDocument rd = null;
            MemoryStream ms = null;
            Stream stream = null;
            try
            {

                var dtStock = _stockService.GetCurrentStockLevelReport(centerno);
                using (rd = new ReportDocument())
                {
                    string rptname = "CRCurrentStockLevel.rpt";
                    string strRptPath = System.Web.HttpContext.Current.Server.MapPath("~/") + "Reports//" + rptname;
                    rd.Load(strRptPath);
                    rd.DataSourceConnections.Clear();
                    rd.SetDataSource(dtStock);

                    rd.SetParameterValue("CName", centerno);

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
                    return Ok(response);

                }

            }
            catch (Exception e)
            {
                log.Error(e);
                throw new HttpResponseException(
                                   Request.CreateErrorResponse(HttpStatusCode.NotFound, e.Message + "." + e.InnerException));
            }
            finally { ms = null; stream = null; rd = null; }
        }
    }
}

