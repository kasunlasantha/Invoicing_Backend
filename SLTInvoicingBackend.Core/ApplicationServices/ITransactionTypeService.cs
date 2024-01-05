using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLTInvoicingBackend.Core.ApplicationServices
{
   public interface ITransactionTypeService : IDisposable
    {
        List<ERP_INV_TRAN_TYPE> GetAllTransactionType();
    }
}
