using Oracle.ManagedDataAccess.Client;
using SLTInvoicingBackend.Core;
using SLTInvoicingBackend.Core.DomainServices;
using SLTInvoicingBackend.Core.Entities;
using SLTInvoicingBackend.Infrastructure.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLTInvoicingBackend.Infrastructure.Repositories
{
    public class ReturngoodRepository: IReturngoodRepository
    {
        readonly IDatabaseContext _ctx;
        int rtSequenceNo = 0;

        public ReturngoodRepository(IDatabaseContext ctx)
        {
            _ctx = ctx;
        }

        public void Dispose()
        {
            if (_ctx != null)
                _ctx.Dispose();
            GC.SuppressFinalize(this);
        }

        // Returns the row in ReturnGood table with max RETSEQ value regard to selected serviceId
        public int GetReturnNo(string serviceId)
        {
            try
            {
                int retNo=0;
                var RetNoFromDB = _ctx.RETURNGOODS
                                    .Where(x => x.STRUSER.Equals(serviceId))
                                    .Select(x => x.RETSEQ)
                                    .Max();
                if(RetNoFromDB == null)
                {
                    retNo = 1;
                }
                else
                {
                    retNo = (int)RetNoFromDB + 1;
                    this.rtSequenceNo = retNo;

                }
                return retNo;

            }
            catch (Exception e)
            {
                throw;
            }
        }

        public Boolean CREATE(RETURNGOOD rETURNGOOD)
        {
            try
            {
                //rETURNGOOD.RETSEQ = rtSequenceNo;
                rETURNGOOD.NOOFITEMS = 1;
                rETURNGOOD.ERP_UPLOAD_STATUS = 0;
                rETURNGOOD.TRYCOUNT = 0;
                rETURNGOOD.ERROR_CODE = "";

                rETURNGOOD.RETSEQ = this.GetReturnNo(rETURNGOOD.STRUSER);
                var invoiceSaved = _ctx.RETURNGOODS.Add(rETURNGOOD);
                _ctx.SaveChanges();
                return true;
            }
            catch (Exception er)
            {

                throw er;
            }
        }

        // Returns all the returngoods by centerNo and IS_COMPLETE = 0(not completed)
        public List<RETURNGOOD> GetAllReturngood(string centerNo)
        {
            try
            {
                var ReturngoodFromDB = _ctx.RETURNGOODS
                             .Where(c => c.CENTERCODE == (centerNo) && c.IS_COMPLETE == 0)
                             .ToList();

                return ReturngoodFromDB;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public List<RPTRETURNNOTE> GetRetDetailsReport(string retNo)
        {
            try
            {
                    OracleParameter param1 = new OracleParameter("@retNo", OracleDbType.Varchar2);
                    OracleParameter param2 = new OracleParameter("@RET_Recordset", OracleDbType.RefCursor, ParameterDirection.Output);


                    param1.Value = retNo;


                    var sql = "BEGIN CASHINV_GETRETUENNOTERPT(:param1,:param2); END;";
                    var rptRet = _ctx.Database.SqlQuery<RPTRETURNNOTE>(sql, param1, param2).ToList();
                    //dsRet.Tables.Add(conv.ConvertToDataTable(rptRet));

                    return rptRet;
            }
            catch (Exception)
            {

                throw ;
            }
        }

        public decimal getReturnAmount(string retno)
        {
            try
            {
                var invNo = _ctx.RETURNGOODS
                            .Where(c => c.RETURNNO == (retno)).SingleOrDefault();

                if(invNo == null)
                {
                    throw new InvalidDataException("Backend: Entered return number not found");
                }
                else
                {
                    var ReturnamtFromDB = _ctx.RETURNGOODS

                   // .GroupBy(x => x.INVOICENO)
                    .Where(c => c.INVOICENO == invNo.INVOICENO && c.IS_COMPLETE == 0)
                    .Sum(x => x.RETURNAMT);

                    decimal value = ReturnamtFromDB.GetValueOrDefault(0m);
                    return value;
                }
     
            }
             catch (Exception e)
            {
                throw;
            }
        }

        /// <summary>
        /// Update retern equipments when done by invoiceing 
        /// </summary>
        /// <param name="serialNum"></param>
        /// <returns></returns>
        public List<RETURNGOOD> UPDATE(string returnNum)
        {
            try
            {
                var invNum = _ctx.RETURNGOODS
                               .Where(o => o.RETURNNO == returnNum).SingleOrDefault();
                             

                var retgood = _ctx.RETURNGOODS
                               .Where(o => o.INVOICENO == invNum.INVOICENO).ToList();
                if (retgood != null)
                {
                    foreach (var item in retgood)
                    {
                        item.IS_COMPLETE = 1;
                    }
                }
                return retgood;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<RPTRETURNSUMMARY> getReturnSummaryRPT(string Fromdate, string ToDate, string BCenterName)
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

                    var sql = "BEGIN RPT_GetReturnSummaryDetails(:param1,:param2,:param3,:param4); END;";
                    var rptRet = _ctx.Database.SqlQuery<RPTRETURNSUMMARY>(sql, param1, param2, param3, param4).ToList();

                    return rptRet;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<RPTRETURNGOODS> getReturnGoodsRPT(string Fromdate, string ToDate, string BCenterName, string ActionName)
        {
            try
            {
                using (var conv = new Converter())
                {//***
                    OracleParameter param1 = new OracleParameter("@P_fromDate", OracleDbType.Varchar2);
                    OracleParameter param2 = new OracleParameter("@P_toDate", OracleDbType.Varchar2);
                    OracleParameter param3 = new OracleParameter("@P_bcenter", OracleDbType.Varchar2);
                    OracleParameter param4 = new OracleParameter("@P_OType", OracleDbType.Varchar2);
                    OracleParameter param5 = new OracleParameter("@Recordset", OracleDbType.RefCursor, ParameterDirection.Output);

                    param1.Value = Fromdate;  //01/15/2010
                    param2.Value = ToDate;    //02/26/2020
                    param3.Value = BCenterName; //CFTS
                    param4.Value = ActionName; // 9

                    var sql = "BEGIN RPT_GetReturnGoodsDetails(:param1,:param2,:param3,:param4,:param5); END;";   
                    var rptRet = _ctx.Database.SqlQuery<RPTRETURNGOODS>(sql, param1, param2, param3, param4, param5).ToList();

                    return rptRet;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<RETURNGOOD> getReturnGoodsDetails(string Fromdate, string ToDate, string optiontype)
        {
            throw new NotImplementedException();
        }

        public void CancelUpdate(string retno)
        {
            try
            {
                var invoino = _ctx.RETURNGOODS
                               .Where(o => o.RETURNNO == retno)
                               .Select(a=> a.INVOICENO).FirstOrDefault();

                var retgood = _ctx.RETURNGOODS
                               .Where(o => o.INVOICENO == invoino).ToList();
                if (retgood != null)
                {
                    foreach (var item in retgood)
                    {
                        item.IS_COMPLETE = 0;
                    }
                }
              
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
