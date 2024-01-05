using SLTInvoicingBackend.Core;
using SLTInvoicingBackend.Core.DomainServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLTInvoicingBackend.Infrastructure.Repositories
{
   public class PurposeofuseRepository : IPurposeofuseRepository
    {
        private readonly IDatabaseContext _ctx;

        public PurposeofuseRepository(IDatabaseContext ctx)
        {
            _ctx = ctx;
        }

        public void Dispose()
        {
            if (_ctx != null)
                _ctx.Dispose();
            GC.SuppressFinalize(this);
        }

        public List<ERP_PURPOSEOFUSE> GetAllPurposeOfuseBytranstype(int trantype)
        {
            try
            {
               return _ctx.ERP_PURPOSEOFUSE.Where(p => p.TRANSACTION_TYPE == trantype).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
