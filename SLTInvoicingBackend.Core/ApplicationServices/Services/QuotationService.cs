using SLTInvoicingBackend.Core.DomainServices;
using SLTInvoicingBackend.Core.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLTInvoicingBackend.Core.ApplicationServices.Services
{
    public class QuotationService : IQuotationService
    {
        readonly IUnitOfWork _uow;
        readonly IQuotationRepository _QuotationRepo;
        readonly ILogRepository _logRepo;

        public QuotationService(IQuotationRepository QuotationRepo, IUnitOfWork uow, ILogRepository logRepo)
        {
            _QuotationRepo = QuotationRepo;
            _uow = uow;
            _logRepo = logRepo;
        }

        public QUOTATIONHEADER CREATE(QUOTATIONHEADER quotation)
        {
            try
            {
                QUOTATIONHEADER result = null;
                string strinvouser = quotation.INVOICEUSER.ToString();
                int intinvouser = Int32.Parse(strinvouser);
                // Get MAx Sequence by centercode and user
                quotation.INVOID = _QuotationRepo.GetMaxSeq(quotation.BCCODE, intinvouser) + 1;

                using (_uow)
                {
                    // SAVE QUOTATION HEADER AND DETAIL
                    result = _QuotationRepo.CREATE(quotation);

                    // Write to Log
                    _logRepo.WriteLog(new OPERATIONSLOG()
                    {
                        LOGINNAME = strinvouser,
                        OPERATION = "New Quotation",
                        DESCRIPTION = quotation.INVOICENO + " Quotation is created",
                        BCCODE = quotation.BCCODE
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

        public string GetQuotationNo(string centerNo, string userId)
        {
            try
            {
                int userSerid = Int32.Parse(userId);
                int maxseq = 0;
                string quotnumber = string.Empty;

                var maxSeq = _QuotationRepo.GetMaxSeq(centerNo, userSerid);
                maxseq = maxSeq + 1;
                quotnumber = "QT" + centerNo + DateTime.Now.ToString("ddMMyy") + userSerid.ToString("0000") + maxseq.ToString("0000");
                return quotnumber;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<RPTQUOTATION> GetRptQuotation(string quotNo)
        {
            try
            {
                return _QuotationRepo.GetInvDetailsReport(quotNo);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
