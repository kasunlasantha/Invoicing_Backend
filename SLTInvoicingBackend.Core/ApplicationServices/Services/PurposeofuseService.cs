using SLTInvoicingBackend.Core.DomainServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLTInvoicingBackend.Core.ApplicationServices.Services
{
    public class PurposeofuseService : IPurposeofuseService
    {
        readonly IPurposeofuseRepository _PurposeRepo;


        public PurposeofuseService(IPurposeofuseRepository PurposeRepo)
        {
            _PurposeRepo = PurposeRepo;

        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public List<ERP_PURPOSEOFUSE> GetPurposeofuseBytrantype(int transtype)
        {
            try
            {
                return _PurposeRepo.GetAllPurposeOfuseBytranstype(transtype);
            }
            catch (Exception)
            {

                throw;
            }
           
        }
    }
}
