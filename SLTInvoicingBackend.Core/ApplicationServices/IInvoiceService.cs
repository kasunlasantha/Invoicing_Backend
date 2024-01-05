using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SLTInvoicingBackend.Core.Entities;

namespace SLTInvoicingBackend.Core.ApplicationServices
{
    public interface IInvoiceService : IDisposable
    {
        List<INVOICEDETAIL> GetAllInvoices();
        INVOICEHEADER GetInvoiceById(string id);
        INVOICEHEADER CREATE(INVOICEHEADER order);
        string GenerateInvoiceNo(string center, string user, int id);
        string GenerateInvoiceTaxNo(string center);
        List<INVOICEHEADER> GetAllInvoicesByCenter(string centerCode);
        List<INVOICEHEADER> GetAllInvoicesByCenter2(string centerCode);
        DataSet GetRptInvcoice(string invno);
        List<INVOICEHEADER> getRjctdInvoicesbyCenter(string centerCode);
        INVOICEHEADER UpdateRejectInvoice(INVOICEHEADER order);
        DataSet CANCEL(string invNo, string canceluser);
        List<RPTDISCOUNTEDSALES> getDiscountedSalesRPT(string Fromdate, string ToDate, string BCenterName);
        List<RPTINVOICESUMMARY> getInvoiceSummaryRPT(string Fromdate, string ToDate, string BCenterName);
        List<RPTITEMSALES> getItemSalesRPT(string Fromdate, string ToDate, string status, string itemcode, string center);
        List<RPTINVOICEHEADER> getInvoiceDetailsRPT(string Fromdate, string ToDate, string BCenterName, string IsTax, string ReceiptStat, string CancelStat);
    }

}
