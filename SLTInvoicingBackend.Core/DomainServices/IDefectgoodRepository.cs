using SLTInvoicingBackend.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLTInvoicingBackend.Core.DomainServices
{
    public interface IDefectgoodRepository: IDisposable
    {
        int GetDefectRecNo();
        Boolean CREATE(DEFECTGOOD dEFECTNGOOD);
        List<RPTDEFECTRETURN> GetRptDefectgood(string defno);
        List<RPTDEFECTSUMMARY> getDefectSummaryRPT(string Fromdate, string ToDate, string BCenterName);
        List<RPTDEFECTGOODS> getDefectGoodsRPT(string Fromdate, string ToDate, string BCenterName);
    }
}
