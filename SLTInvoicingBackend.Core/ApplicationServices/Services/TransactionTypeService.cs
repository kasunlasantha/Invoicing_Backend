using SLTInvoicingBackend.Core.DomainServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLTInvoicingBackend.Core.ApplicationServices.Services
{
    public class TransactionTypeService : ITransactionTypeService
    {
        readonly ITransactionTypeRepository _TransRepo;


        public TransactionTypeService(ITransactionTypeRepository transRepo)
        {
            _TransRepo = transRepo;

        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public List<ERP_INV_TRAN_TYPE> GetAllTransactionType()
        {
            try
            {
                return _TransRepo.GetAllTransactionType();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
