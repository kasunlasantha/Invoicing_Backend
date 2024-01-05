using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLTInvoicingBackend.Core.DomainServices
{
    public interface IPurposeofuseRepository : IDisposable
    {
        List<ERP_PURPOSEOFUSE> GetAllPurposeOfuseBytranstype(int trantype);
    }
}
