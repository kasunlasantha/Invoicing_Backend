using SLTInvoicingBackend.Core;
using SLTInvoicingBackend.Core.DomainServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLTInvoicingBackend.Infrastructure.Repositories
{
    public class TransactionTypeRepository : ITransactionTypeRepository
    {
        private readonly IDatabaseContext _ctx;

        public TransactionTypeRepository(IDatabaseContext ctx)
        {
            _ctx = ctx;
        }

        public void Dispose()
        {
            if (_ctx != null)
                _ctx.Dispose();
            GC.SuppressFinalize(this);
        }

        public List<ERP_INV_TRAN_TYPE> GetAllTransactionType()
        {
            try
            {
                return _ctx.ERP_INV_TRAN_TYPE.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
