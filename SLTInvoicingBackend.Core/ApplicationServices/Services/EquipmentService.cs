using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SLTInvoicingBackend.Core.DomainServices;
using SLTInvoicingBackend.Core.DomainServices.Filtering;
using SLTInvoicingBackend.Core.Entities;

namespace SLTInvoicingBackend.Core.ApplicationServices.Services
{
    public class EquipmentService : IEquipmentService
    {
        readonly IEquipmentRepository _equiRepo;
        readonly ILogRepository _logRepo;

        public EquipmentService(IEquipmentRepository equiRepo, ILogRepository logRepo)
        {
            _equiRepo = equiRepo;
            _logRepo = logRepo;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public FilteredList<EQUIPMENT> ReadAll()
        {
            try
            {
              return  _equiRepo.ReadAll();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<EQUIPMENT> ReadyByCenter(string code)
        {
            try
            {
                return _equiRepo.ReadyByCenter(code);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public EQUIPMENT ReadyByCode(string code)
        {
            try
            {
                return _equiRepo.ReadyByCode(code);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<EQUIPMENT> ReadyByCenter2(string code)
        {
            try
            {
                return _equiRepo.ReadyByCenter2(code);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
