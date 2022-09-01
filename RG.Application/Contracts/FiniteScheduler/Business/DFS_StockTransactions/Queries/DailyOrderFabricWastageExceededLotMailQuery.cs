using MediatR;
using RG.Application.Common.Models;
using RG.Application.Contracts.FiniteScheduler.Business.DFS_StockTransactions.Queries.RequestResponseModel;
using RG.Application.Interfaces.Services.FiniteScheduler.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.FiniteScheduler.Business.DFS_StockTransactions.Queries
{
    public class DailyOrderFabricWastageExceededLotMailQuery :IRequest<RResult>
    {
        public DateTime ReportDate { get { return DateTime.Now.AddDays(-1); } }
    }
    public class DailyOrderFabricWastageExceededLotMailQueryHandler : IRequestHandler<DailyOrderFabricWastageExceededLotMailQuery, RResult>
    {
        private readonly IDFS_StockTransactionService _dFS_StockTransactionService;

        public DailyOrderFabricWastageExceededLotMailQueryHandler(IDFS_StockTransactionService dFS_StockTransactionService)
        {
            _dFS_StockTransactionService = dFS_StockTransactionService;
        }
        public async Task<RResult> Handle(DailyOrderFabricWastageExceededLotMailQuery request, CancellationToken cancellationToken)
        {
            RResult rResult = new RResult();

            await _dFS_StockTransactionService.GetDailyOrderFabricWastageExceededLot(request.ReportDate);
            return rResult;

        }
        
    }
}
