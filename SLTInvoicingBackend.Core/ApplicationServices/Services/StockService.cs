using SLTInvoicingBackend.Core.DomainServices;
using SLTInvoicingBackend.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLTInvoicingBackend.Core.ApplicationServices.Services
{
    public class StockService : IStockService
    {
        readonly IStockRepository _stockRepo;


        public StockService(IStockRepository stockRepo)
        {
            _stockRepo = stockRepo;

        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public int GetStockInHand(string equ, string center)
        {
            int stock_in_hand = 0;
            try
            {
                var stock = _stockRepo.GetStockBycode(equ, center);
                stock_in_hand = Convert.ToInt32(stock.RECEIVEDQTY - (stock.SOLDQTY + stock.RESERVEDQTY));  //+ stock.DEFECTEDQTY
                return stock_in_hand;
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
                var stock = _stockRepo.GetCurrentStockLevelReport(centerNo);
                return stock;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<RPTCURRENTSTOCKLEVEL> GetCurrentStockLevel(string centerNo)
        {
            try
            {
                var stock = _stockRepo.GetCurrentStockLevelReport(centerNo);
                return stock;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
