using SLTInvoicingBackend.Core.DomainServices.Filtering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLTInvoicingBackend.Core.DomainServices
{
    public interface ILogRepository : IDisposable
    {
        OPERATIONSLOG WriteLog(OPERATIONSLOG log);
      FilteredList<OPERATIONSLOG> ReadAll();
    }
}
