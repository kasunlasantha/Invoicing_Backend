using SLTInvoicingBackend.Core.DomainServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLTInvoicingBackend.Core.ApplicationServices.Services
{
   public class TaxService : ITaxService
    {
        readonly ITaxRepository _taxRepo;
       

        public TaxService(ITaxRepository taxRepo)
        {
            _taxRepo = taxRepo;
          
        }

        public TAX GetTaxByCode(string taxcode)
        {
            try
            {
                return _taxRepo.GetTaxbyCode(taxcode);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<TAX> GetTaxByequcode(string equ)
        {
            try
            {
              return  _taxRepo.GetTaxByequcode(equ);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
