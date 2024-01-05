using System;
using SLTInvoicingBackend.Core.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLTInvoicingBackend.Core.DomainServices
{
    public interface IGRNDataRepository : IDisposable
    {
        List<RPTGoodsReceivedNotesDetails> getGoodsReceivedNotesDetailsRPT(string Fromdate, string ToDate, string BCenterName);
    }
}
