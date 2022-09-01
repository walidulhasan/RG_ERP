using RG.Application.Common.Models;
using RG.Application.Contracts.FiniteScheduler.Business.DFS_StockTransactions.Queries.RequestResponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Services.FiniteScheduler.Business
{
    public interface IDFS_StockTransactionService
    {
        Task<RResult> GetFabricQuantityAndPantoneByLotID(long LotID);
        Task GetDailyOrderFabricWastageExceededLot(DateTime? CurrentDate = null);
    }
}
