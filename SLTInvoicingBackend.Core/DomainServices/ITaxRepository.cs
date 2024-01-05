using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLTInvoicingBackend.Core.DomainServices
{
    public interface ITaxRepository : IDisposable
    {
        List<TAX> GetTaxByequcode(string equ);
        TAX GetTaxbyCode(string taxCode);
    }
}
