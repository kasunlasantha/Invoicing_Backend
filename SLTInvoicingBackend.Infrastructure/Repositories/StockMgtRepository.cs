using SLTInvoicingBackend.Core;
using SLTInvoicingBackend.Core.DomainServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLTInvoicingBackend.Infrastructure.Repositories
{
    public class StockMgtRepository : IStockMgtRepository
    {
        private readonly IDatabaseContext  _ctx;
        public StockMgtRepository(IDatabaseContext ctx)
        {
            _ctx = ctx;
        }

        public STOCKMGT CREATE(STOCKMGT stock)
        {
            try
            {
                var stockmgtSaved = _ctx.STOCKMGTs.Add(stock);
                return stockmgtSaved;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Dispose()
        {
            if (_ctx != null)
                _ctx.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
