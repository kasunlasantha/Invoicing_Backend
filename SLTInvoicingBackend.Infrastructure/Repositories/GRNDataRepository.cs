using SLTInvoicingBackend.Core.DomainServices;
using SLTInvoicingBackend.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Oracle.ManagedDataAccess.Client;
using SLTInvoicingBackend.Infrastructure.Common;
using System.Data;


namespace SLTInvoicingBackend.Infrastructure.Repositories
{
   public class GRNDataRepository: IGRNDataRepository
    {
        readonly IDatabaseContext _ctx;
        int rtSequenceNo = 0;

        public GRNDataRepository(IDatabaseContext ctx)
        {
            _ctx = ctx;
        }

        public void Dispose()
        {
            if (_ctx != null)
                _ctx.Dispose();
            GC.SuppressFinalize(this);
        }

        public List<RPTGoodsReceivedNotesDetails> getGoodsReceivedNotesDetailsRPT(string Fromdate, string ToDate, string BCenterName)
        {
            try
            {
                using (var conv = new Converter())
                {
                    OracleParameter param1 = new OracleParameter("@P_fromDate", OracleDbType.Varchar2);
                    OracleParameter param2 = new OracleParameter("@P_toDate", OracleDbType.Varchar2);
                    OracleParameter param3 = new OracleParameter("@P_bcenter", OracleDbType.Varchar2);
                    OracleParameter param4 = new OracleParameter("@Recordset", OracleDbType.RefCursor, ParameterDirection.Output);

                    param1.Value = Fromdate;  //01/15/2010
                    param2.Value = ToDate;    //01/31/2020
                    param3.Value = BCenterName;

                    var sql = "BEGIN RPT_GetGRNDetails(:param1,:param2,:param3,:param4); END;";
                    var rptRet = _ctx.Database.SqlQuery<RPTGoodsReceivedNotesDetails>(sql, param1, param2, param3, param4).ToList();

                    return rptRet;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
