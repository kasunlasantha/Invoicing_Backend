using Oracle.ManagedDataAccess.Client;
using SLTInvoicingBackend.Core;
using SLTInvoicingBackend.Core.DomainServices;
using SLTInvoicingBackend.Core.Entities;
using SLTInvoicingBackend.Infrastructure.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Z.EntityFramework.Plus;

namespace SLTInvoicingBackend.Infrastructure.Repositories
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly IDatabaseContext _ctx;

        public InvoiceRepository(IDatabaseContext ctx)
        {
            _ctx = ctx;
        }

        // Returns a list of all Invoices
        public List<INVOICEDETAIL> GetAllInvoices()
        {
            throw new NotImplementedException();
        }

        // Returns an Invoice by recived id
        public INVOICEHEADER GetInvoiceById(string id)
        {
            try
            {
                var InvoiceFromDB = _ctx.INVOICEHEADERs
                    .Include("INVOICEDETAILS")
                    .Where(c => c.INVOICENO == (id))
                   .FirstOrDefault();
                return InvoiceFromDB;

            }
            catch (Exception e)
            {
                throw;
            }

        }

        // Make IS_RETURNED = 1 
        public void UpdateInvoDetailIsRet(string invoNo, string serialno)
        {
            try
            {
                //var InvoiceFromDB = _ctx.INVOICEDETAILS.Select(a=> a.IS_RETURNED).Where(c => c. == (id))
                //             .Where(c => c. == (id))
                //             .FirstOrDefault();
                //return InvoiceFromDB;

                var InvoiceDetailFromDB = _ctx.INVOICEDETAILS
                        .Where(c => c.INVOICENO.Equals(invoNo) && c.SERIALS.Equals(serialno))
                        .FirstOrDefault();
                if (InvoiceDetailFromDB != null)
                {
                    InvoiceDetailFromDB.IS_RETURNED = 1;
                }

            }
            catch (Exception e)
            {
                throw;
            }

        }

        public void Dispose()
        {
            if (_ctx != null)
                _ctx.Dispose();
            GC.SuppressFinalize(this);
        }

        public INVOICEHEADER CREATE(INVOICEHEADER order)
        {
            try
            {
                var invoiceSaved = _ctx.INVOICEHEADERs.Add(order);

                return invoiceSaved;
            }
            catch (Exception er)
            {

                throw er;
            }
        }

        

        public int GetMaxSeq(string center,string user)
        {
            try
            {
                var maxseq = _ctx.INVOICEHEADERs
                            .Where(c => c.BCCODE == center && c.INVOICEUSER == user && DbFunctions.TruncateTime(c.INVOICEDATE.Value) == DbFunctions.TruncateTime(DateTime.Now))
                            .AsNoTracking()
                            .Max(x => x.INVOID);
                
                return Convert.ToInt16(maxseq);
                               
            }
            catch (Exception)
            {

                throw;
            }
        }

        // Returns a list of all Invoices (within past 15 days) by Centercode (used in return form)
        public List<INVOICEHEADER> GetAllInvoicesByCenter(string centerCode)
        {
            try
            {
                //var baselineDate = DateTime.Now.AddDays(-15);
                //var InvoiceFromDB = _ctx.INVOICEHEADERs
                //    .Include("INVOICEDETAILS")
                //             .Where(c => c.BCCODE == (centerCode) && c.INVOICEDATE >= baselineDate && c.RECEIPTSTAT == 1 && c.CANCELSTAT == 0)
                //             .ToList();

                //return InvoiceFromDB;

                var baselineDate = DateTime.Now.AddDays(-15);
                var InvoiceFromDB = _ctx.INVOICEHEADERs
                    .IncludeFilter(b => b.INVOICEDETAILS.Where(e => e.IS_RETURNED == 0).OrderBy(e => e.SERIALS))
                             .Where(c => c.BCCODE == (centerCode) && DbFunctions.TruncateTime(c.INVOICEDATE) >= DbFunctions.TruncateTime(baselineDate) && c.RECEIPTSTAT == 1 && c.CANCELSTAT == 0)
                             .ToList();
                var InvoiceWdetails = InvoiceFromDB.Where(q => q.INVOICEDETAILS.Count > 0).ToList();

                return InvoiceWdetails;

            }
            catch (Exception e)
            {
                throw;
            }
        }

        // Returns a list of all Invoices from invoice table WHERE CancelStat != 1 AND InvoType= 1 AND ReceiptStat = 1 AND in past 10 days (used in defect form)
        public List<INVOICEHEADER> GetAllInvoicesforDefect(string centerCode)
        {
            try
            {
                var baselineDate = DateTime.Now.AddDays(-365);
                var InvoiceFromDB = _ctx.INVOICEHEADERs
                    .IncludeFilter(b => b.INVOICEDETAILS.Where(e => e.IS_RETURNED == 0).OrderBy(e => e.SERIALS))
                             .Where(c => c.BCCODE == (centerCode) && DbFunctions.TruncateTime(c.INVOICEDATE) >= DbFunctions.TruncateTime(baselineDate) && c.RECEIPTSTAT == 1 && c.CANCELSTAT == 0)
                             .AsNoTracking()
                             .ToList();
                var InvoiceWdetails = InvoiceFromDB.Where(q => q.INVOICEDETAILS.Count > 0).ToList();

                return InvoiceWdetails;

            }
            catch (Exception e)
            {
                throw;
            }
        }

        public int GetMaxTaxSeq(string center)
        {
            try
            {
                var maxseq = _ctx.INVOICEHEADERs
                            .Where(c => c.BCCODE == center && DbFunctions.TruncateTime(c.INVOICEDATE.Value) == DbFunctions.TruncateTime(DateTime.Now))
                            .AsNoTracking()
                            .Max(x => x.TAXID);
                return Convert.ToInt16(maxseq);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public DataSet GetInvDetailsReport(string invNo)
        {
            DataSet dsInv = new DataSet();
            try
            {
                using (var conv=new Converter())
                {
                    OracleParameter param1 = new OracleParameter("@invNo", OracleDbType.Varchar2);
                    OracleParameter param2 = new OracleParameter("@INV_Recordset", OracleDbType.RefCursor, ParameterDirection.Output);


                    param1.Value = invNo;


                    var sql = "BEGIN RPT_GetInvoiceDetail(:param1,:param2); END;";
                    var rptInv = _ctx.Database.SqlQuery<RPTINVOICE>(sql, param1, param2).ToList();
                    var sqltax = "BEGIN RPT_GetInvoiceDetailTAX(:param1,:param2); END;";
                    var rptInvTAX = _ctx.Database.SqlQuery<RPTINVOICETAX>(sqltax, param1, param2).ToList();
                    dsInv.Tables.Add( conv.ConvertToDataTable(rptInv));
                    dsInv.Tables.Add(conv.ConvertToDataTable(rptInvTAX));

                    return dsInv;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<INVOICEHEADER> getRjctdInvoicesbyCenter(string centerCode)
        {
            try
            {
                var InvoiceFromDB = _ctx.INVOICEHEADERs
                    .IncludeFilter(b => b.INVOICEDETAILS.Where(e => e.ERP_UPLOAD_STATUS == -1))
                             .Where(c => c.BCCODE == (centerCode) && c.CANCELSTAT == 0)
                             .ToList();

                var InvoiceRjtdetails = InvoiceFromDB.Where(q => q.INVOICEDETAILS.Count > 0).ToList();

                return InvoiceRjtdetails;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public INVOICEHEADER UPDATE(INVOICEHEADER order)
        {
            try
            {

                var existInvHeader = _ctx.INVOICEHEADERs
                    .Include("INVOICEDETAILS")
                    .Where(c => c.INVOICENO.Equals(order.INVOICENO)).FirstOrDefault();
                if (existInvHeader == null) throw new InvalidDataException("Backend : Invoice not found for updating");
              
                //Update parent
                var entry = _ctx.Entry(existInvHeader);
                (entry).CurrentValues.SetValues(order);

                // Update children
                foreach (var childModel in order.INVOICEDETAILS)
                {
                    var existingChild = existInvHeader.INVOICEDETAILS
                  .Where(c => c.INVODEID == childModel.INVODEID)
                  .SingleOrDefault();

                    if (existingChild != null)
                        // Update child
                        _ctx.Entry(existingChild).CurrentValues.SetValues(childModel);

                }
               
               return order;


            }
            catch (Exception er)
            {

                throw er;
            }
        }

        public List<RPTDISCOUNTEDSALES> getDiscountedSalesRPT(string Fromdate, string ToDate, string BCenterName)
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

                    var sql = "BEGIN RPT_GetSalesDiscountDetails(:param1,:param2,:param3,:param4); END;";
                    var rptRet = _ctx.Database.SqlQuery<RPTDISCOUNTEDSALES>(sql, param1, param2, param3, param4).ToList();

                    return rptRet;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<RPTINVOICESUMMARY> getInvoiceSummaryRPT(string Fromdate, string ToDate, string BCenterName)
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

                    var sql = "BEGIN RPT_GetInvoiceSummaryDetails(:param1,:param2,:param3,:param4); END;";
                    var rptRet = _ctx.Database.SqlQuery<RPTINVOICESUMMARY>(sql, param1, param2, param3, param4).ToList();

                    return rptRet;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// this method is used cancel invoice, search invoice
        /// </summary>
        /// <param name="centerCode"></param>
        /// <returns></returns>
        public List<INVOICEHEADER> GetAllInvoicesByCenter2(string centerCode)
        {
            try
            {
                var InvoiceFromDB = _ctx.INVOICEHEADERs
                   .Include("INVOICEDETAILS")
                            .Where(c =>  c.CANCELSTAT != 1 && c.BCCODE == centerCode)
                            .ToList();

                return InvoiceFromDB;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<RPTITEMSALES> getItemSalesRPT(string Fromdate, string ToDate, string status, string itemcode, string center)
        {
            try
            {
                OracleParameter param1 = new OracleParameter("@date1", OracleDbType.Varchar2);
                OracleParameter param2 = new OracleParameter("@date2", OracleDbType.Varchar2);
                OracleParameter param3 = new OracleParameter("@st", OracleDbType.Varchar2);
                OracleParameter param4 = new OracleParameter("@ICode", OracleDbType.Varchar2);
                OracleParameter param5 = new OracleParameter("@center", OracleDbType.Varchar2);
                OracleParameter param6 = new OracleParameter("@RET_Recordset", OracleDbType.RefCursor, ParameterDirection.Output);


                param1.Value = Fromdate;
                param2.Value = ToDate;
                param3.Value = status;
                param4.Value = itemcode;
                param5.Value = center;


                var sql = "BEGIN CASHINV_GETITEMSALESDETAILS(:param1,:param2,:param3,:param4,:param5,:param6); END;";
                var rptItemSale = _ctx.Database.SqlQuery<RPTITEMSALES>(sql, param1, param2, param3, param4, param5, param6).ToList();

                return rptItemSale;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<RPTINVOICEHEADER> getInvoiceDetailsRPT(string Fromdate, string ToDate, string BCenterName, string IsTax, string ReceiptStat, string CancelStat)
        {
            try
            {
                using (var conv = new Converter())
                {
                    OracleParameter param1 = new OracleParameter("@P_fromDate", OracleDbType.Varchar2);
                    OracleParameter param2 = new OracleParameter("@P_toDate", OracleDbType.Varchar2);
                    OracleParameter param3 = new OracleParameter("@P_bcenter", OracleDbType.Varchar2);
                    OracleParameter param4 = new OracleParameter("@P_isTax", OracleDbType.Varchar2);
                    OracleParameter param5 = new OracleParameter("@P_receiptStat", OracleDbType.Varchar2);
                    OracleParameter param6 = new OracleParameter("@P_cancelStat", OracleDbType.Varchar2);
                    OracleParameter param7 = new OracleParameter("@Recordset", OracleDbType.RefCursor, ParameterDirection.Output);

                    param1.Value = Fromdate;  //01/15/2010
                    param2.Value = ToDate;    //01/31/2020
                    param3.Value = BCenterName;
                    param4.Value = IsTax;
                    param5.Value = ReceiptStat;
                    param6.Value = CancelStat;

                    var sql = "BEGIN RPT_GetInvoiceDetails(:param1,:param2,:param3,:param4,:param5,:param6,:param7); END;";
                    var rptRet = _ctx.Database.SqlQuery<RPTINVOICEHEADER>(sql, param1, param2, param3, param4, param5, param6, param7).ToList();

                    return rptRet;
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        public string GetCostcode(string invNo)
        {
            try
            {
                return _ctx.INVOICEHEADERs
               .Where(c => c.INVOICENO == invNo)
               .Select(a=> a.COSTCODE)
                     .FirstOrDefault();
            }
            catch (Exception e)
            {

                throw new InvalidDataException("Backend: COSTCODE not found");
            }
        }
    }
}
