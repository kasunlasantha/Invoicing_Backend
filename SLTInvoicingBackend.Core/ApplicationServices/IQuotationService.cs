using SLTInvoicingBackend.Core.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLTInvoicingBackend.Core.ApplicationServices
{
    public interface IQuotationService: IDisposable
    {
        string GetQuotationNo(string centerNo, string userId);
        QUOTATIONHEADER CREATE(QUOTATIONHEADER quotation);
        List<RPTQUOTATION> GetRptQuotation(string quotNo);
    }
}
