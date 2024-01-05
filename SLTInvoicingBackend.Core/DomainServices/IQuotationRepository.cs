using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SLTInvoicingBackend.Core.Entities;

namespace SLTInvoicingBackend.Core.DomainServices
{
    public interface IQuotationRepository: IDisposable
    {
        int GetMaxSeq(string centerNo, int userId);
        QUOTATIONHEADER CREATE(QUOTATIONHEADER quotation);
        List<RPTQUOTATION> GetInvDetailsReport(string quotNo);
    }
}
