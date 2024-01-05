using System;
using System.Collections.Generic;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;
using SLTInvoicingBackend.Core.DomainServices;
using SLTInvoicingBackend.Core.DomainServices.Filtering;

namespace SLTInvoicingBackend.Core.ApplicationServices.Services
{
    public class CashierService : ICashierService
    {
        readonly ICashierRepository _cashiRepo;
        readonly ILogRepository _logRepo;
        readonly IUnitOfWork _uow;

        public CashierService(ICashierRepository cashiRepo, ILogRepository logRepo, IUnitOfWork uow)
        {
            _cashiRepo = cashiRepo;
            _logRepo = logRepo;
            _uow = uow;
        }
        //test comment
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
                if (CheckDomainUser(user.CA_SERVICEID, user.CA_PASSWORD))
                {
                    using (_uow)
                    {
                        var cashi_out = _cashiRepo.SignIn(user);
                        _logRepo.WriteLog(new OPERATIONSLOG()
                        {
                            LOGINNAME = cashi_out.CA_NAME,
                            OPERATION = "Login",
                            DESCRIPTION = cashi_out.CA_SERVICEID + " Login sucessfully",
                            BCCODE = cashi_out.BC_CODE
                        });
                        _uow.Commit();
                        return cashi_out;
                    }

                }
                else
                {
                    throw new AuthenticationException("Backend: User fails to login, user is not found in domain");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool CheckDomainUser(string serviceid, string pass)
        {
             return true;
            //using (PrincipalContext context = new PrincipalContext(ContextType.Domain))
            //{
            //    return context.ValidateCredentials(serviceid, pass);
            //    //return true;

            //}

        }

        public bool SignOff(int cashierId)
        {
            try
            {
                using (_uow)
                {
                    var booOk = _cashiRepo.SignOff(cashierId);
                    _logRepo.WriteLog(new OPERATIONSLOG()
                    {
                        LOGINNAME = booOk.CA_NAME,
                        OPERATION = "LoginOff",
                        DESCRIPTION = booOk.CA_SERVICEID + " LoginOff sucessfully",
                        BCCODE = booOk.BC_CODE
                    });
                    _uow.Commit();
                    return true;
                }
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
