using Oracle.ManagedDataAccess.Client;
using SLTInvoicingBackend.Core;
using SLTInvoicingBackend.Core.DomainServices;
using SLTInvoicingBackend.Core.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLTInvoicingBackend.Infrastructure.Repositories
{
    public class StockRepository : IStockRepository
    {
        private readonly IDatabaseContext _ctx;

        public StockRepository(IDatabaseContext ctx)
        {
            _ctx = ctx;
        }
        public void Dispose()
        {
            if (_ctx != null)
                _ctx.Dispose();
            GC.SuppressFinalize(this);
        }

        public STOCK GetStockBycode(string equ, string center)
        {
            try
            {
                var stock = _ctx.STOCKs
                        .Where(c => c.EQUCODE.Equals(equ) && c.BC_CODE == center)
                        .AsNoTracking()
                        .FirstOrDefault();
                if (stock == null) throw new InvalidDataException("Backend: Stock is not available");
                return stock;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public STOCK UPDATE(STOCK _stock)
        {
            try
            {
                var stock = _ctx.STOCKs
                        .Where(c => c.EQUCODE.Equals(_stock.EQUCODE) && c.BC_CODE == _stock.BC_CODE)
                        //.AsNoTracking()
                        .FirstOrDefault();
                if (stock != null)
                {
                    if (_stock.RECEIVEDQTY == 1) stock.RECEIVEDQTY = stock.RECEIVEDQTY + 1;
                    if (_stock.SOLDQTY == 1) stock.SOLDQTY = stock.SOLDQTY + 1;
                    if (_stock.RESERVEDQTY == 1) stock.RESERVEDQTY = stock.RESERVEDQTY + 1;
                    if (_stock.DEFECTEDQTY == 1) stock.DEFECTEDQTY = stock.DEFECTEDQTY + 1;
                    if (_stock.SOLDQTY == -1) stock.SOLDQTY = stock.SOLDQTY - 1;
                    if (_stock.RESERVEDQTY == -1) stock.RESERVEDQTY = stock.RESERVEDQTY - 1;
                }


                return stock;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<RPTCURRENTSTOCKLEVEL> GetCurrentStockLevelReport(string centerNo)
        {
            try
            {
                OracleParameter param1 = new OracleParameter("@centerNo", OracleDbType.Varchar2);
                OracleParameter param2 = new OracleParameter("@RET_Currentstock", OracleDbType.RefCursor, ParameterDirection.Output);


                param1.Value = centerNo;


                var sql = "BEGIN CASHINV_GETCURRENTSTOCK(:param1,:param2); END;";
                var rptRet = _ctx.Database.SqlQuery<RPTCURRENTSTOCKLEVEL>(sql, param1, param2).ToList();
                //dsRet.Tables.Add(conv.ConvertToDataTable(rptRet));

                return rptRet;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
