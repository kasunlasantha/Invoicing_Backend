using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLTInvoicingBackend.Core.ApplicationServices
{
    public interface ITaxService
    {
        List<TAX> GetTaxByequcode(string equ);
        TAX GetTaxByCode(string taxcode);
    }
}
