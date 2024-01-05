using SLTInvoicingBackend.Core.DomainServices.Filtering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLTInvoicingBackend.Core.ApplicationServices
{
    public interface ICashierService
    {
        FilteredList<CASHIER> ReadAll();
        CASHIER CreateCashier(CASHIER createuser);
        CASHIER SignIn(CASHIER user);
        CASHIER ReadyById(int id);
        bool CheckDomainUser(string serviceid, string pass);
        bool SignOff(int cashierId);

    }
}
