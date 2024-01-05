using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SLTInvoicingBackend.Core.DomainServices;
using SLTInvoicingBackend.Core.Entities;

namespace SLTInvoicingBackend.Core.ApplicationServices.Services
{
    public class ReturngoodService: IReturngoodService
    {
        readonly IReturngoodRepository _retGoodRepo;
        readonly ILogRepository _logRepo;
        readonly IStockMgtRepository _stockmgtRepo;
        readonly IUnitOfWork _uow;
        readonly IStockRepository _stockRepo;
        readonly IInvoiceRepository _invoiceRepo;

        public ReturngoodService(IReturngoodRepository retGoodRepo, ILogRepository logRepo, IStockMgtRepository stockmgtRepo, IUnitOfWork uow, IStockRepository stockRepo, IInvoiceRepository invoiceRepo)
        {
            _retGoodRepo = retGoodRepo;
            _logRepo = logRepo;
            _stockmgtRepo = stockmgtRepo;
            _uow = uow;
            _stockRepo = stockRepo;
            _invoiceRepo = invoiceRepo;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public string GetReturnNo(string centerNo, int userId, string serviceId)
        {
            string strRN;
            try
            {
                strRN = "RT" + centerNo + userId.ToString("0000") + _retGoodRepo.GetReturnNo(serviceId).ToString("0000");
                return strRN;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Boolean CREATE(RETURNGOOD rETURNGOOD)
        {
            try
            {
                bool result = false;

                using (_uow)
                {
                    // CREATE RETURNGOOD
                    int is_completed = 0;
                    if(rETURNGOOD.OPTIONTYPE == 10)
                    {
                        is_completed = 1;
                    }
                    rETURNGOOD.IS_COMPLETE = is_completed;
                    result = _retGoodRepo.CREATE(rETURNGOOD);

                    // make IS_RETURNED =1 in INVOICEDETAILS table 
                    _invoiceRepo.UpdateInvoDetailIsRet(rETURNGOOD.INVOICENO, rETURNGOOD.RETURNSERIAL);

                    ////UPDATE STOCK TABLE
                    _stockRepo.UPDATE(new STOCK()
                    {
                        EQUCODE = rETURNGOOD.ITEMCODE,
                        BC_CODE = rETURNGOOD.CENTERCODE,
                        SOLDQTY = -1
                    });

                    //INSERT STOCKMGT TABLE

                    string costcode = _invoiceRepo.GetCostcode(rETURNGOOD.INVOICENO);

                    _stockmgtRepo.CREATE(new STOCKMGT()
                    {
                        EQUCODE = rETURNGOOD.ITEMCODE,
                        BC_CODE = rETURNGOOD.CENTERCODE,
                        INVOICENO = rETURNGOOD.INVOICENO,
                        RECEIVED_QTY = 0,
                        SOLD_QTY = 0,
                        RESERVED_QTY = 0,
                        DEFECTED_QTY = 0,
                        INCREASED_QTY = 0,
                        DECREASED_QTY = 0,
                        OPENING_QTY = 0,
                        CLOSING_QTY = 0,
                        STATUS = 0,
                        REFDATE = DateTime.Now,
                        ENTRYTYPE = 0,
                        RETURN_QTY = 1,
                        COSTCODE = costcode
                    });

                    _logRepo.WriteLog(new OPERATIONSLOG()
                    {
                        LOGINNAME = rETURNGOOD.STRUSER,
                        OPERATION = "New ReturnGood",
                        DESCRIPTION = rETURNGOOD.INVOICENO + " ReturnGood is created",
                        BCCODE = rETURNGOOD.CENTERCODE
                    });

                    _uow.Commit();

                }

                return result;
            }
            catch
            {
                throw;
            }
            
        }

        public List<RETURNGOOD> GetAllReturngood(string centerNo)
        {
            try
            {
                return _retGoodRepo.GetAllReturngood(centerNo);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<RPTRETURNNOTE> GetRptReturngood(string retno)
        {
            try
            {
                return _retGoodRepo.GetRetDetailsReport(retno);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public decimal getReturnAmount(string retno)
        {
            try
            {
                return _retGoodRepo.getReturnAmount(retno);
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public List<RPTRETURNSUMMARY> getReturnSummaryRPT(string Fromdate, string ToDate, string BCenterName)
        {
            try
            {
                return _retGoodRepo.getReturnSummaryRPT(Fromdate, ToDate, BCenterName);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<RPTRETURNGOODS> getReturnGoodsRPT(string Fromdate, string ToDate, string BCenterName, string ActionName)
        {
            try
            {
                return _retGoodRepo.getReturnGoodsRPT(Fromdate, ToDate, BCenterName, ActionName);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
