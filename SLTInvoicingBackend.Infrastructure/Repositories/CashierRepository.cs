using SLTInvoicingBackend.Core;
using SLTInvoicingBackend.Core.DomainServices;
using SLTInvoicingBackend.Core.DomainServices.Filtering;
using System;
using System.Linq;
using System.IO;
using System.Data.Entity;

namespace SLTInvoicingBackend.Infrastructure.Repositories
{
    public class CashierRepository : ICashierRepository
    {
        readonly IDatabaseContext _ctx;

        public CashierRepository(IDatabaseContext ctx)
        {
            _ctx = ctx;
        }

        public CASHIER CreateCashier(CASHIER createuser)
        {
            throw new NotImplementedException();
        }

       

        public FilteredList<CASHIER> ReadAll()
        {
            throw new NotImplementedException();
        }

        public CASHIER ReadyById(int id)
        {
            throw new NotImplementedException();
        }

        public CASHIER SignIn(CASHIER user)
        {
            try
            {
                var userFromDB = _ctx.CASHIERs
                             .Include("BILLINGCENTER")
                             .Where(c => c.CA_SERVICEID.Equals(user.CA_SERVICEID) && c.BC_CODE == user.BC_CODE && c.STATUS != 12 && c.STATUS != 11)
                             .AsNoTracking().FirstOrDefault();

                var erpInitCheckStatus = _ctx.ERP_INIT_CHECK
                            .Where(x => x.CENTRE.Equals(user.BC_CODE) && DbFunctions.TruncateTime(x.DATETIME)== DbFunctions.TruncateTime(DateTime.Now))
                            .Select(x => x.STATUS)
                            .AsNoTracking().FirstOrDefault();

                if (erpInitCheckStatus == "1")
                {
                    throw new InvalidDataException("Backend : Incomplete processes are pending to be posted to the ERP system. Thus unable to operate the Invoicing application with incorrect stock information. Please complete the processes and try again.");
                }
                if (erpInitCheckStatus == null)
                {
                    throw new InvalidDataException("Backend : Opening stock is not downloaded.Please contact IT officer.");
                }
                if (userFromDB != null)
                {
                    if (userFromDB.STATUS == 1) throw new InvalidDataException("Backend: Cashier is already logged in");

                    userFromDB.STATUS = 1;
                    userFromDB.CA_LOG_DATE = DateTime.Now;
                }

                else
                {
                    throw new InvalidDataException("Backend: User fails to login, Cashier not found");
                }
                user = null;
                return userFromDB;
            }
            catch (Exception e)
            {

                throw e;
            }
           

        }

        public CASHIER SignOff(int cashierId)
        {
            try
            {
                var user= _ctx.CASHIERs
                     .Where(c => c.CA_ID.Equals(cashierId))
                     .FirstOrDefault();
                if (user == null) throw new InvalidDataException("Backend: Cashier ID not found");

                user.STATUS = 0;
                user.CA_CLOSE_DATE = DateTime.Now;
              
                return user;

            }
            catch (Exception)
            {

                throw;
            }
        }

        //public int Commit()
        //{
        //    try
        //    {
        //       return _ctx.SaveChanges();
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}


        public void Dispose()
        {
            if (_ctx != null)
                _ctx.Dispose();
            GC.SuppressFinalize(this);
        }

       
    }
}