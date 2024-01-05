using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SLTInvoicingBackend.Core.Entities;

namespace SLTInvoicingBackend.Core.DomainServices
{
    public interface IInvoiceRepository : IDisposable
    {
        List<INVOICEDETAIL> GetAllInvoices();
        INVOICEHEADER GetInvoiceById(string id);
        INVOICEHEADER CREATE(INVOICEHEADER order);
        int GetMaxSeq(string center, string user);
        int GetMaxTaxSeq(string center);
        List<INVOICEHEADER> GetAllInvoicesByCenter(string centerCode);
        List<INVOICEHEADER> GetAllInvoicesByCenter2(string centerCode);
        List<INVOICEHEADER> GetAllInvoicesforDefect(string centerCode);
        DataSet GetInvDetailsReport(string invNo);
        void UpdateInvoDetailIsRet(string invoNo, string serialno);
        List<INVOICEHEADER> getRjctdInvoicesbyCenter(string centerCode);
        INVOICEHEADER UPDATE(INVOICEHEADER order); //getDiscountedSalesRPT(Fromdate, ToDate, BCenterName)
        List<RPTDISCOUNTEDSALES> getDiscountedSalesRPT(string Fromdate, string ToDate, string BCenterName);
        List<RPTINVOICESUMMARY> getInvoiceSummaryRPT(string Fromdate, string ToDate, string BCenterName);
        List<RPTITEMSALES> getItemSalesRPT(string Fromdate, string ToDate, string status, string itemcode, string center);
        List<RPTINVOICEHEADER> getInvoiceDetailsRPT(string Fromdate, string ToDate, string BCenterName, string IsTax, string ReceiptStat, string CancelStat);
        string GetCostcode(string invNo);

    }
}
