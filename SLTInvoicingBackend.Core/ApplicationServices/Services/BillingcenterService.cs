using SLTInvoicingBackend.Core.DomainServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLTInvoicingBackend.Core.ApplicationServices.Services
{
    public class BillingcenterService : IBillingcenterService
    {
        readonly IBillingcenterRepository _billingcenterRepository;

        public BillingcenterService(IBillingcenterRepository billingcenterRepository)
        {
            _billingcenterRepository = billingcenterRepository;
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
        //test at home
        public string[] GetBillingcenterNo()
        {
            try
            {
                return _billingcenterRepository.GetBillingCenterNo();
            }
            catch (Exception)
            {

                throw;
            }
            
        }
    }
}
