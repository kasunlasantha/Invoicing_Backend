using SLTInvoicingBackend.Core.DomainServices.Filtering;
using SLTInvoicingBackend.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLTInvoicingBackend.Core.ApplicationServices
{
    public interface IEquipmentService : IDisposable
    {
        FilteredList<EQUIPMENT> ReadAll();
        EQUIPMENT ReadyByCode(string code);
        List<EQUIPMENT> ReadyByCenter(string code);
        List<EQUIPMENT> ReadyByCenter2(string code);
    }
}
