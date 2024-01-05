using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
using SLTInvoicingBackend.Core;
using SLTInvoicingBackend.Core.DomainServices;
using SLTInvoicingBackend.Core.Entities;

namespace SLTInvoicingBackend.Infrastructure.Repositories
{
    public class QuotationRepository : IQuotationRepository
    {
        readonly IDatabaseContext _ctx;

        public QuotationRepository(IDatabaseContext ctx)
        {
            _ctx = ctx;
        }

        public QUOTATIONHEADER CREATE(QUOTATIONHEADER quotation)
        {
            try
            {
                var quotationSaved = _ctx.QUOTATIONHEADERs.Add(quotation);

                return quotationSaved;
            }
            catch (Exception er)
            {

                throw er;
            }
        }

        public void Dispose()
        {
            if (_ctx != null)
                _ctx.Dispose();
            GC.SuppressFinalize(this);
        }

        public int GetMaxSeq(string centerNo, int userId)
        {
            try
            {
                var maxseq = _ctx.QUOTATIONHEADERs
                .Where(c => c.BCCODE == centerNo && c.INVOICEUSER == userId)
                .Max(x => x.INVOID);
                return Convert.ToInt16(maxseq);

            }
            catch (Exception e)
            {
                throw;
            }
        }

        List<RPTQUOTATION> IQuotationRepository.GetInvDetailsReport(string quotNo)
        {
            try
            {
                    OracleParameter param1 = new OracleParameter("@qoutNo", OracleDbType.Varchar2);
                    OracleParameter param2 = new OracleParameter("@QOT_Recordset", OracleDbType.RefCursor, ParameterDirection.Output);

                    param1.Value = quotNo;

                    var sql = "BEGIN RPT_GETQUOTATIONDETAIL(:param1,:param2); END;";
                    var rptInv = _ctx.Database.SqlQuery<RPTQUOTATION>(sql, param1, param2).ToList();

                    return rptInv;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
