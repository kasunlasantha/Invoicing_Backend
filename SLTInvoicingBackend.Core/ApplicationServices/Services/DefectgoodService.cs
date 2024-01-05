using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SLTInvoicingBackend.Core.DomainServices;
using SLTInvoicingBackend.Core.Entities;

namespace SLTInvoicingBackend.Core.ApplicationServices.Services
{
    public class DefectgoodService: IDefectgoodService
    {
        readonly IDefectgoodRepository _defGoodRepo;
        readonly ILogRepository _logRepo;
        readonly IInvoiceRepository _invoRepo;
        readonly IUnitOfWork _uow;
        readonly IStockRepository _stockRepo;
        readonly IStockMgtRepository _stockmgtRepo;

        public DefectgoodService(ILogRepository logRepo, IDefectgoodRepository defRepo, IInvoiceRepository invoRepo, IUnitOfWork uow, IStockMgtRepository stockmgtRepo, IStockRepository stockRepo)
        {
            _defGoodRepo = defRepo;
            _logRepo = logRepo;
            _invoRepo = invoRepo;
            _uow = uow;
            _stockRepo = stockRepo;
            _stockmgtRepo = stockmgtRepo;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public string GetDefectRecNo(string centerNo, int userId, string serviceId)
        {
            string strDF;
            try
            {
                strDF = "DEF" + centerNo + userId.ToString("0000") + _defGoodRepo.GetDefectRecNo().ToString("000");
                return strDF;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<INVOICEHEADER> GetAllInvoices(string centerCode)
        {
            try
            {
                return _invoRepo.GetAllInvoicesforDefect(centerCode);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Boolean CREATE(DEFECTGOOD dEFECTGOOD)
        {
            try
            {
                bool result = false;

                using (_uow)
                {
                    // CREATE RETURNGOOD
                    result = _defGoodRepo.CREATE(dEFECTGOOD);

                    // make IS_RETURNED =1 in INVOICEDETAILS table 
                    _invoRepo.UpdateInvoDetailIsRet(dEFECTGOOD.INVOICENO, dEFECTGOOD.DEFECTSERIAL);

                    ////UPDATE STOCK TABLE
                    _stockRepo.UPDATE(new STOCK()
                    {
                        EQUCODE = dEFECTGOOD.ITEMCODE,
                        BC_CODE = dEFECTGOOD.BCCODE,
                        DEFECTEDQTY = 1,
                        //SOLDQTY = 1,
                    });

                    //INSERT STOCKMGT TABLE

                    string costcode = _invoRepo.GetCostcode(dEFECTGOOD.INVOICENO);

                    _stockmgtRepo.CREATE(new STOCKMGT()
                    {
                        EQUCODE = dEFECTGOOD.ITEMCODE,
                        BC_CODE = dEFECTGOOD.BCCODE,
                        INVOICENO = dEFECTGOOD.INVOICENO,
                        RECEIVED_QTY = 0,
                        SOLD_QTY = 0,
                        RESERVED_QTY = 0,
                        DEFECTED_QTY = 1,
                        INCREASED_QTY = 0,
                        DECREASED_QTY = 0,
                        OPENING_QTY = 0,
                        CLOSING_QTY = 0,
                        STATUS = 0,
                        REFDATE = DateTime.Now,
                        ENTRYTYPE = 0,
                        RETURN_QTY = 0,
                        COSTCODE = costcode
                    });

                    _logRepo.WriteLog(new OPERATIONSLOG()
                    {
                        LOGINNAME = dEFECTGOOD.STRUSER,
                        OPERATION = "New DefectGood",
                        DESCRIPTION = dEFECTGOOD.INVOICENO + " DefectGood is created",
                        BCCODE = dEFECTGOOD.BCCODE
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

        public List<RPTDEFECTRETURN> GetRptDefectgood(string retno)
        {
            try
            {
                return _defGoodRepo.GetRptDefectgood(retno);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<RPTDEFECTSUMMARY> getDefectSummaryRPT(string Fromdate, string ToDate,string BCenterName)
        {
            try
            {
                return _defGoodRepo.getDefectSummaryRPT(Fromdate, ToDate, BCenterName);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<RPTDEFECTGOODS> getDefectGoodsRPT(string Fromdate, string ToDate, string BCenterName)
        {
            try
            {
                return _defGoodRepo.getDefectGoodsRPT(Fromdate, ToDate, BCenterName);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
