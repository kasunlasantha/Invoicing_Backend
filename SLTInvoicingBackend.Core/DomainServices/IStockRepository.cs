using SLTInvoicingBackend.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLTInvoicingBackend.Core.DomainServices
{
    public interface IStockRepository : IDisposable
    {
        STOCK GetStockBycode(string equ, string center);
        STOCK UPDATE(STOCK _stock);
        List<RPTCURRENTSTOCKLEVEL> GetCurrentStockLevelReport(string centerNo);
    }
}
