using Oracle.ManagedDataAccess.Client;
using SLTInvoicingBackend.Core;
using SLTInvoicingBackend.Core.DomainServices;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLTInvoicingBackend.Infrastructure.Repositories
{
    public class TaxRepository : ITaxRepository
    {
        private readonly IDatabaseContext _ctx;

        public TaxRepository(IDatabaseContext ctx)
        {
            _ctx = ctx;
        }

        public void Dispose()
        {
            if (_ctx != null)
                _ctx.Dispose();
            GC.SuppressFinalize(this);
        }

        public TAX GetTaxbyCode(string taxCode)
        {
            try
            {
                return _ctx.TAXes.Where(x => x.TAXCODE == taxCode).FirstOrDefault();
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
                OracleParameter param1 = new OracleParameter("@STREQUCODE", OracleDbType.Varchar2);
                OracleParameter param2 = new OracleParameter("@E_Recordset", OracleDbType.RefCursor, ParameterDirection.Output);

                
                param1.Value = equ;
                

                var sql = "BEGIN GETTAXBYEQUCODE(:param1,:param2); END;";
                var tax = _ctx.Database.SqlQuery<TAX>(sql, param1, param2).ToList();
                return tax;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
