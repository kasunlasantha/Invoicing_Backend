using SLTInvoicingBackend.Core.DomainServices.Filtering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLTInvoicingBackend.Core.DomainServices
{
    public interface ICashierRepository : IDisposable
    {
        FilteredList<CASHIER> ReadAll();
        CASHIER CreateCashier(CASHIER createuser);
        CASHIER SignIn(CASHIER user);
        CASHIER ReadyById(int id);
        CASHIER SignOff(int cashierId);
        //int Commit();
    }
}
