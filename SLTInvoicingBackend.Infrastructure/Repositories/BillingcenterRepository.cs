using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SLTInvoicingBackend.Core.DomainServices;
using SLTInvoicingBackend.Core;
using System.Data.Entity;

namespace SLTInvoicingBackend.Infrastructure.Repositories
{
    public class BillingcenterRepository : IBillingcenterRepository
    {
        readonly InvoicingContext _ctx;
        public BillingcenterRepository(InvoicingContext ctx)
        {
            _ctx = ctx;
        }
        public void Dispose()
        {
            if (_ctx != null)
                _ctx.Dispose();
            GC.SuppressFinalize(this);
        }

        // Returns all the code numbers form Billingcenter table
        public string[] GetBillingCenterNo()
        {
            string[] bcCodes = { };
            try
            {
                bcCodes = _ctx.BILLINGCENTERs.Select(x => x.BC_CODE).AsNoTracking().ToArray();

            }
            catch (Exception e)
            {
                throw;
            }
            return bcCodes;
        }
    }
}
