using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SLTInvoicingBackend.Core.Entities;
using SLTInvoicingBackend.Core.Entities;

namespace SLTInvoicingBackend.Core.ApplicationServices
{
    public interface IReturngoodService: IDisposable
    {
        string GetReturnNo(string centerNo, int userId, string serviceId);
        Boolean CREATE(RETURNGOOD rETURNGOOD);
        List<RETURNGOOD> GetAllReturngood(string centerNo);
        List<RPTRETURNNOTE> GetRptReturngood(string retno);
        decimal getReturnAmount(string retno);
        List<RPTRETURNSUMMARY> getReturnSummaryRPT(string Fromdate, string ToDate, string BCenterName);
        List<RPTRETURNGOODS> getReturnGoodsRPT(string Fromdate, string ToDate, string BCenterName, string ActionName);
    }
}
