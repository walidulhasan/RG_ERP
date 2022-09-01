using RG.Application.Common.Models;
using RG.Application.Contracts.FiniteScheduler.Business.DFS_StockTransactions.Queries.RequestResponseModel;
using RG.DBEntities.FiniteScheduler.Business;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Repositories.FiniteScheduler.Business
{
  public  interface IDFS_StockTransactionRepository:IGenericRepository<DFS_StockTransaction>
    {
        //Task<RResult> SaveDFSStockTransaction(DFS_StockTransactionViewModel dfsStockTransaction, int createdBy, bool saveChanges = true);
        //Task<RResult> SaveDFSStockTransaction(List<DFS_StockTransactionViewModel> dfsStockTransaction, int createdBy, bool saveChanges = true);
        Task<RResult> GetFabricQuantityAndPantoneByLotID(long LotID);
        Task<OrderWiseFabricStatusAndLotInfoSVM> GetDailyOrderFabricWastageExceededLot(DateTime? CurrentDate=null);
    }
}
