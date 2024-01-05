using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLTInvoicingBackend.Core.ApplicationServices
{
    public interface IBillingcenterService: IDisposable
    {
        string[] GetBillingcenterNo();
    }
}
