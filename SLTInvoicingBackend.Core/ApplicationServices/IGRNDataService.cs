using SLTInvoicingBackend.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLTInvoicingBackend.Core.ApplicationServices
{
    public interface IGRNDataService : IDisposable
    {
        List<RPTGoodsReceivedNotesDetails> getGoodsReceivedNotesDetailsRPT(string Fromdate, string ToDate, string BCenterName);
    }
}
