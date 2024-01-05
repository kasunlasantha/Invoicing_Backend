using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
using SLTInvoicingBackend.Core;
using SLTInvoicingBackend.Core.DomainServices;
using SLTInvoicingBackend.Core.Entities;
using SLTInvoicingBackend.Infrastructure.Common;
using SLTInvoicingBackend.Core.Entities;

namespace SLTInvoicingBackend.Infrastructure.Repositories
{
    public class DefectgoodRepository : IDefectgoodRepository
    {
        readonly InvoicingContext _ctx;
        int defSequenceNo = 0;

        public DefectgoodRepository(InvoicingContext ctx)
        {
            _ctx = ctx;
        }

        public void Dispose()
        {
            if (_ctx != null)
                _ctx.Dispose();
            GC.SuppressFinalize(this);
        }

        // Returns the max DEFSEQ value in DefectGoods table
        public int GetDefectRecNo()
        {
            try
            {
                int defNo = 0;
                var RetNoFromDB = _ctx.DEFECTGOODS
                                    .Select(x => x.DEFSEQ)
                                    .Max();
                if (RetNoFromDB == null)
                {
                    defNo = 1;
                }
                else
                {
                    defNo = (int)RetNoFromDB + 1;
                    this.defSequenceNo = defNo;

                }
                return defNo;

            }
            catch (Exception e)
            {
                throw;
            }
        }

        public Boolean CREATE(DEFECTGOOD dEFECTNGOOD)
        {
            try
            {
                //rETURNGOOD.RETSEQ = rtSequenceNo;
                dEFECTNGOOD.NOOFITEMS = 1;
                dEFECTNGOOD.ERP_UPLOAD_STATUS = 0;
                dEFECTNGOOD.TRYCOUNT = 0;
                dEFECTNGOOD.ERROR_CODE = "";

                dEFECTNGOOD.DEFSEQ = this.GetDefectRecNo();
                var invoiceSaved = _ctx.DEFECTGOODS.Add(dEFECTNGOOD);
                _ctx.SaveChanges();
                return true;
            }
            catch (Exception er)
            {

                throw er;
            }
        }

        public List<RPTDEFECTRETURN> GetRptDefectgood(string defno)
        {
            try
            {
                    OracleParameter param1 = new OracleParameter("@defNo", OracleDbType.Varchar2);
                    OracleParameter param2 = new OracleParameter("@DEF_Recordset", OracleDbType.RefCursor, ParameterDirection.Output);


                    param1.Value = defno;


                    var sql = "BEGIN CASHIINV_GETDEFECTITEMDETAILS(:param1,:param2); END;";
                    var rptDef = _ctx.Database.SqlQuery<RPTDEFECTRETURN>(sql, param1, param2).ToList();
                    //dsRet.Tables.Add(conv.ConvertToDataTable(rptRet));

                    return rptDef;
            }
            catch (Exception)
            {

                throw;
            }
        }


        public List<RPTDEFECTSUMMARY> getDefectSummaryRPT(string Fromdate, string ToDate, string BCenterName)
        {
            try
            {
                using (var conv = new Converter())
                {
                    OracleParameter param1 = new OracleParameter("@P_fromDate", OracleDbType.Varchar2);
                    OracleParameter param2 = new OracleParameter("@P_toDate", OracleDbType.Varchar2);
                    OracleParameter param3 = new OracleParameter("@P_bcenter", OracleDbType.Varchar2);
                    OracleParameter param4 = new OracleParameter("@Recordset", OracleDbType.RefCursor, ParameterDirection.Output);

                    param1.Value = Fromdate;
                    param2.Value = ToDate;
                    param3.Value = BCenterName;

                    var sql = "BEGIN RPT_GETDEFECTSUMMARYDETAILS(:param1,:param2,:param3,:param4); END;";
                    var rptRet = _ctx.Database.SqlQuery<RPTDEFECTSUMMARY>(sql, param1, param2, param3, param4).ToList();
                      
                    return rptRet;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<RPTDEFECTGOODS> getDefectGoodsRPT(string Fromdate, string ToDate, string BCenterName)
        {
            try
            {
                using (var conv = new Converter())
                {
                    OracleParameter param1 = new OracleParameter("@P_fromDate", OracleDbType.Varchar2);
                    OracleParameter param2 = new OracleParameter("@P_toDate", OracleDbType.Varchar2);
                    OracleParameter param3 = new OracleParameter("@P_bcenter", OracleDbType.Varchar2);
                    OracleParameter param4 = new OracleParameter("@Recordset", OracleDbType.RefCursor, ParameterDirection.Output);

                    param1.Value = Fromdate;
                    param2.Value = ToDate;
                    param3.Value = BCenterName;

                    var sql = "BEGIN RPT_GetDefectGoodsDetails(:param1,:param2,:param3,:param4); END;";
                    var rptRet = _ctx.Database.SqlQuery<RPTDEFECTGOODS>(sql, param1, param2, param3, param4).ToList();

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
