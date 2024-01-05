using SLTInvoicingBackend.Core.Entities;
using System;
using System.Collections.Generic;

namespace SLTInvoicingBackend.Core.DomainServices
{
    public interface IReturngoodRepository: IDisposable 
    {
        int GetReturnNo(string serviceId);
        Boolean CREATE(RETURNGOOD rETURNGOOD);
        List<RETURNGOOD> GetAllReturngood(string centerNo);
        List<RPTRETURNNOTE> GetRetDetailsReport(string retNo);
        List<RETURNGOOD> UPDATE(string returnNum);
        decimal getReturnAmount(string retno);
        List<RPTRETURNSUMMARY> getReturnSummaryRPT(string Fromdate, string ToDate, string BCenterName);
        List<RPTRETURNGOODS> getReturnGoodsRPT(string Fromdate, string ToDate, string BCenterName, string ActionName);
        List<RETURNGOOD> getReturnGoodsDetails(string Fromdate, string ToDate, string optiontype);
        void CancelUpdate(string invono);
    }
}
