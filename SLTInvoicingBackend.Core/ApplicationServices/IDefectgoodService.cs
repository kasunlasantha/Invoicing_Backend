using SLTInvoicingBackend.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLTInvoicingBackend.Core.ApplicationServices
{
    public interface IDefectgoodService: IDisposable
    {
        string GetDefectRecNo(string centerNo, int userId, string serviceId);
        List<INVOICEHEADER> GetAllInvoices(string centerCode);
        Boolean CREATE(DEFECTGOOD dEFECTNGOOD);
        List<RPTDEFECTRETURN> GetRptDefectgood(string defno);
        List<RPTDEFECTSUMMARY> getDefectSummaryRPT(string Fromdate, string ToDate, string BCenterName);
        List<RPTDEFECTGOODS> getDefectGoodsRPT(string Fromdate, string ToDate, string BCenterName);
    }
}
