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
    public class InvoiceService : IInvoiceService
    {
        readonly IInvoiceRepository _invoRepo;
        readonly ILogRepository _logRepo;
        readonly IStockMgtRepository _stockmgtRepo;
        readonly IStockRepository _stockRepo;
        readonly IReturngoodRepository _returnRepo;
        readonly IUnitOfWork _uow;

        public InvoiceService(IInvoiceRepository invoRepo, ILogRepository logRepo, IStockMgtRepository stockmgtRepo,
         IUnitOfWork uow, IStockRepository stockRepo, IReturngoodRepository returnRepo)
        {
            _invoRepo = invoRepo;
            _logRepo = logRepo;
            _stockmgtRepo = stockmgtRepo;
            _uow = uow;
            _stockRepo = stockRepo;
            _returnRepo = returnRepo;
        }

        public INVOICEHEADER CREATE(INVOICEHEADER order)
        {
            try
            {
                INVOICEHEADER result = null;
                order.INVOID = _invoRepo.GetMaxSeq(order.BCCODE, order.INVOICEUSER) + 1;
                //if Tax invoice will be perfomerd to generate tax number and next tax seq
                if (order.ISTAX == 2) 
                {
                    order.TAXID = _invoRepo.GetMaxTaxSeq(order.BCCODE) + 1;
                    order.TAXSEQNO = this.GenerateInvoiceTaxNo(order.BCCODE);
                }
               

                using (_uow)
                {
                    // SAVE INVOICE HEADER AND DETAIL
                    result = _invoRepo.CREATE(order);
                    foreach (var item in order.INVOICEDETAILS)
                    {
                        //UPDATE STOCK TABLE
                        _stockRepo.UPDATE(new STOCK()
                        {
                            EQUCODE = item.ITEMCODE,
                            BC_CODE = order.BCCODE,
                            RESERVEDQTY = 1

                        });

                        //INSERT STOCKMGT TABLE
                        _stockmgtRepo.CREATE(new STOCKMGT()
                        {
                            EQUCODE = item.ITEMCODE,
                            BC_CODE = order.BCCODE,
                            COSTCODE = order.COSTCODE,
                            INVOICENO = item.INVOICENO,
                            RECEIVED_QTY = 0,
                            SOLD_QTY = 0,
                            RESERVED_QTY = 1,
                            DEFECTED_QTY = 0,
                            INCREASED_QTY = 0,
                            DECREASED_QTY = 0,
                            OPENING_QTY = 0,
                            CLOSING_QTY = 0,
                            STATUS = 1,
                            REFDATE = DateTime.Now,
                            ENTRYTYPE = 0,
                            RETURN_QTY = 0
                        });
                    }

                    // when return invoice came , update the returngoods table flag (Is_Complete).
                    if (!string.IsNullOrEmpty(order.RETURNINVNO))
                    {
                        _returnRepo.UPDATE(order.RETURNINVNO);
                    }

                    _logRepo.WriteLog(new OPERATIONSLOG()
                    {
                        LOGINNAME = order.INVOICEUSER,
                        OPERATION = "New Invoice",
                        DESCRIPTION = order.INVOICENO + " Invoice is created",
                        BCCODE = order.BCCODE
                    });

                    _uow.Commit();
                }

                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public string GenerateInvoiceNo(string center, string user, int id)
        {
           
            int userid = id;
            int maxseq = 0;
            string invonumber = string.Empty;
            try
            {
                var maxSeq = _invoRepo.GetMaxSeq(center, user);
                maxseq = maxSeq + 1;
                invonumber = center + DateTime.Now.ToString("ddMMyy") + userid.ToString("0000") + maxseq.ToString("0000");
                return invonumber;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<INVOICEDETAIL> GetAllInvoices()
        {
            throw new NotImplementedException();
        }

        public INVOICEHEADER GetInvoiceById(string id)
        {
            try
            {
                return _invoRepo.GetInvoiceById(id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<INVOICEHEADER> GetAllInvoicesByCenter(string centerCode)
        {
            try
            {
                return _invoRepo.GetAllInvoicesByCenter(centerCode);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public string GenerateInvoiceTaxNo(string center)
        {
            
            int maxseq = 0;
            string invonumber = string.Empty;
            try
            {
                var maxSeq = _invoRepo.GetMaxTaxSeq(center);
                maxseq = maxSeq + 1;
                invonumber = DateTime.Now.ToString("ddMyy") + "TAX" + maxseq.ToString("0000");
                return invonumber;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public DataSet GetRptInvcoice(string invno)
        {
            try
            {
                return _invoRepo.GetInvDetailsReport(invno);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<INVOICEHEADER> getRjctdInvoicesbyCenter(string centerCode)
        {
            try
            {
                return _invoRepo.getRjctdInvoicesbyCenter(centerCode);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public INVOICEHEADER UpdateRejectInvoice(INVOICEHEADER order)
        {
            try
            {
                var dbInvoice = _invoRepo.GetInvoiceById(order.INVOICENO);
                //get old serial
                var oldSerial = dbInvoice.INVOICEDETAILS.Select(x => x.SERIALS).FirstOrDefault();

                var newSerial = order.INVOICEDETAILS.Select(x => x.SERIALS).FirstOrDefault();

                foreach (var item in order.INVOICEDETAILS)
                {
                    foreach (var invoicdetails in dbInvoice.INVOICEDETAILS.Where(x=>x.INVODEID== item.INVODEID))
                    {
                        invoicdetails.SERIALS = item.SERIALS;
                    }
                }


                //_invoice = _invoRepo.GetInvoiceById(order.INVOICENO);


                foreach (var item in dbInvoice.INVOICEDETAILS)
                {
                    item.ERP_UPLOAD_STATUS = 0;
                    item.TRYCOUNT = 0;
                    item.RETURN_CODE = "";
                    item.RETURN_MESSAGE = "";
                }

                INVOICEHEADER result = null;
                using (_uow)
                {

                    // UPDATE INVOICE HEADER AND DETAIL
                    result = _invoRepo.UPDATE(dbInvoice);

                    _logRepo.WriteLog(new OPERATIONSLOG()
                    {
                        LOGINNAME = order.INVOICEUSER,
                        OPERATION = "Rejected Invoice Details Updated",
                        DESCRIPTION = order.INVOICENO+ " " + oldSerial + " " + newSerial,
                        BCCODE = order.BCCODE
                    });

                    _uow.Commit();
                }

                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public DataSet CANCEL(string invNo, string canceluser)
        {
            INVOICEHEADER _invoice = null;
            DataSet cancelResult = null;
            try
            {
                using (_uow)
                {
                     _invoice = _invoRepo.GetInvoiceById(invNo);
                    _invoice.CANCELSTAT = 1;
                    _invoice.CANCELDATE = DateTime.Now;
                    _invoice.CANCELUSER = canceluser;
                    var _update = _invoRepo.UPDATE(_invoice);

                    foreach (var item in _invoice.INVOICEDETAILS)
                    {
                        //UPDATE STOCK TABLE
                        _stockRepo.UPDATE(new STOCK()
                        {
                            EQUCODE = item.ITEMCODE,
                            BC_CODE = _invoice.BCCODE,
                            RESERVEDQTY = -1

                        });

                        //INSERT STOCKMGT TABLE
                        _stockmgtRepo.CREATE(new STOCKMGT()
                        {
                            EQUCODE = item.ITEMCODE,
                            BC_CODE = _invoice.BCCODE,
                            COSTCODE = _invoice.COSTCODE,
                            INVOICENO = item.INVOICENO,
                            RECEIVED_QTY = 0,
                            SOLD_QTY = 0,
                            RESERVED_QTY = -1,
                            DEFECTED_QTY = 0,
                            INCREASED_QTY = 0,
                            DECREASED_QTY = 0,
                            OPENING_QTY = 0,
                            CLOSING_QTY = 0,
                            STATUS = 0,
                            REFDATE = DateTime.Now,
                            ENTRYTYPE = 0,
                            RETURN_QTY = 0
                        });
                    }

                    _returnRepo.CancelUpdate(_invoice.RETURNINVNO);
                    _logRepo.WriteLog(new OPERATIONSLOG()
                    {
                        LOGINNAME = canceluser,
                        OPERATION = "Cancel Invoice",
                        DESCRIPTION = _invoice.INVOICENO + " Invoice is cancelled",
                        BCCODE = _invoice.BCCODE
                    });

                     cancelResult = _invoRepo.GetInvDetailsReport(invNo);
                    _uow.Commit();

                }
                return cancelResult;
            }
            catch (Exception)
            {

                throw;
            }
        }


        public List<RPTDISCOUNTEDSALES> getDiscountedSalesRPT(string Fromdate, string ToDate, string BCenterName)
        {
            try
            {
                return _invoRepo.getDiscountedSalesRPT(Fromdate, ToDate, BCenterName);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<RPTINVOICESUMMARY> getInvoiceSummaryRPT(string Fromdate, string ToDate, string BCenterName)
        {
            try
            {
                return _invoRepo.getInvoiceSummaryRPT(Fromdate, ToDate, BCenterName);
            }
            catch (Exception)
            {

                throw;
            }
        }



        public List<INVOICEHEADER> GetAllInvoicesByCenter2(string centerCode)
        {
            try
            {
                return _invoRepo.GetAllInvoicesByCenter2(centerCode);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<RPTITEMSALES> getItemSalesRPT(string Fromdate, string ToDate, string status, string itemcode, string center)
        {
            try
            {
                return _invoRepo.getItemSalesRPT(Fromdate, ToDate, status, itemcode, center);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<RPTINVOICEHEADER> getInvoiceDetailsRPT(string Fromdate, string ToDate, string BCenterName, string IsTax, string ReceiptStat, string CancelStat)
        {
            try
            {
                return _invoRepo.getInvoiceDetailsRPT(Fromdate, ToDate, BCenterName, IsTax, ReceiptStat, CancelStat);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
