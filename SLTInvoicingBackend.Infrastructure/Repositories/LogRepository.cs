using SLTInvoicingBackend.Core;
using SLTInvoicingBackend.Core.DomainServices;
using SLTInvoicingBackend.Core.DomainServices.Filtering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLTInvoicingBackend.Infrastructure.Repositories
{
    public class LogRepository : ILogRepository
    {
        readonly IDatabaseContext _ctx;

        public LogRepository(IDatabaseContext ctx)
        {
            _ctx = ctx;
        }

      

        public FilteredList<OPERATIONSLOG> ReadAll()
        {
            throw new NotImplementedException();
        }

        public OPERATIONSLOG WriteLog(OPERATIONSLOG log)
        {
            try
            {
                log.EVENTDATE = DateTime.Now.Date;
                log.EVENTTIME = DateTime.Now;
                log.DIVISION = "Invoicing";

               var logResult= _ctx.OPERATIONSLOGs.Add(log);
                return logResult;
            }
            catch (Exception)
            {

                throw;
            }
            finally { log = null; }
        }

        public void Dispose()
        {
            if (_ctx != null)
                _ctx.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
