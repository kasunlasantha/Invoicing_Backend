using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SLTInvoicingBackend.Core.DomainServices;
using SLTInvoicingBackend.Core.Entities;

namespace SLTInvoicingBackend.Core.ApplicationServices.Services
{
    public class GRNDataService: IGRNDataService
    {
        readonly IGRNDataRepository _igrnDataRepo;

        public GRNDataService(ILogRepository logRepo, IGRNDataRepository igrnRepo)
        {
            _igrnDataRepo = igrnRepo;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public List<RPTGoodsReceivedNotesDetails> getGoodsReceivedNotesDetailsRPT(string Fromdate, string ToDate, string BCenterName)
        {
            try
            {
                return _igrnDataRepo.getGoodsReceivedNotesDetailsRPT(Fromdate, ToDate, BCenterName);
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
