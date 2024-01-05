using SLTInvoicingBackend.Core;
using SLTInvoicingBackend.Core.DomainServices;
using SLTInvoicingBackend.Core.DomainServices.Filtering;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Data.Entity;
using Z.EntityFramework.Plus;

namespace SLTInvoicingBackend.Infrastructure.Repositories
{
    public class EquipmentRepository : IEquipmentRepository
    {
        readonly IDatabaseContext _ctx;

        public EquipmentRepository(IDatabaseContext ctx)
        {
            _ctx = ctx;
        }

        public void Dispose()
        {
            if (_ctx != null)
                _ctx.Dispose();
            GC.SuppressFinalize(this);
        }

        public FilteredList<EQUIPMENT> ReadAll()
        {
            try
            {
                //Create a Filtered List
                var filteredList = new FilteredList<EQUIPMENT>();
                filteredList.List = _ctx.EQUIPMENTs
                    .Where(c => c.EQUBLOCK==0).AsNoTracking();
                filteredList.Count = _ctx.EQUIPMENTs.Count();

                return filteredList;

            }
            catch (Exception)
            {

                throw new InvalidDataException("Backend: Equipment Retrieving error");
            }
        }

        public List<EQUIPMENT> ReadyByCenter(string code)
        {
            try
            {
                var baselineDate = DateTime.Now;
                var equList= _ctx.EQUIPMENTs
                    .Where(c => c.EQUBLOCK == 0)

                    .IncludeFilter(c => c.PRICEREVISIONS.Where(p => p.ACTIVE == 0 && (p.CENTER==code || p.CENTER=="ALL") &&
                      (DbFunctions.TruncateTime(p.STARTING) <= DbFunctions.TruncateTime(baselineDate)) &&
                    (DbFunctions.TruncateTime(p.ENDING)  >= DbFunctions.TruncateTime(baselineDate) || p.TYPE !=2)))  
                    
                    .IncludeFilter(c => c.STOCKs.Where(i => i.BC_CODE == code))
                   .AsNoTracking()
                   .ToList();

                return equList;
                
            }
            catch (Exception)
            {

                throw;
            }
        }


        //public List<EQUIPMENT> ReadyByCenter2(string code)
        //{
        //    try
        //    {

        //        var baselineDate = DateTime.Now;
        //        var equList = _ctx.EQUIPMENTs
        //            .Where(c => c.EQUBLOCK == 0 && c.STOCKs.Select(x => x.EQUCODE).Contains(c.EQUCODE))

        //            .IncludeFilter(c => c.PRICEREVISIONS.Where(p => p.ACTIVE == 0 && (p.CENTER == code || p.CENTER == "ALL") &&
        //              (DbFunctions.TruncateTime(p.STARTING) <= DbFunctions.TruncateTime(baselineDate)) &&
        //            (DbFunctions.TruncateTime(p.ENDING) >= DbFunctions.TruncateTime(baselineDate) || p.TYPE != 2)))

        //            .IncludeFilter(c => c.STOCKs.Where(i => i.BC_CODE == code))
        //           .AsNoTracking()
        //           .ToList();

        //        return equList;

        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}

        public List<EQUIPMENT> ReadyByCenter2(string code)
        {
            try
            {

                var baselineDate = DateTime.Now;
                var equList = (_ctx.EQUIPMENTs
                    

                    .IncludeFilter(c => c.PRICEREVISIONS.Where(p => p.ACTIVE == 0 && (p.CENTER == code || p.CENTER == "ALL") &&
                      (DbFunctions.TruncateTime(p.STARTING) <= DbFunctions.TruncateTime(baselineDate)) &&
                    (DbFunctions.TruncateTime(p.ENDING) >= DbFunctions.TruncateTime(baselineDate) || p.TYPE != 2)))

                    .IncludeFilter(c => c.STOCKs.Where(i => i.BC_CODE == code)))
                    .Where(c => c.EQUBLOCK == 0 && c.STOCKs.Where(i => i.BC_CODE == code).Select(x => x.EQUCODE).Contains(c.EQUCODE))
                   .AsNoTracking()
                   .ToList();

                return equList;

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
                return _ctx.EQUIPMENTs
                    .Include("STOCKs")
               .Where(c => c.EQUBLOCK==0 && (c.EQUCODE.Equals(code)||c.BARCODE.Equals(code)))
                     .AsNoTracking()
                     .FirstOrDefault();
            }
            catch (Exception e)
            {

                throw new InvalidDataException("Backend: Equipment not found");
            }
        }

        
    }
}
