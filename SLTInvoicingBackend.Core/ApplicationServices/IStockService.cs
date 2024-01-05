using SLTInvoicingBackend.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLTInvoicingBackend.Core.ApplicationServices
{
    public interface IStockService : IDisposable
    {
        int GetStockInHand(string equ, string center);
        List<RPTCURRENTSTOCKLEVEL> GetCurrentStockLevelReport(string centerNo);
        List<RPTCURRENTSTOCKLEVEL> GetCurrentStockLevel(string centerNo);
    }
}
