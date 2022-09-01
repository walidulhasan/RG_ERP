using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Common.Models;
using RG.DBEntities.FiniteScheduler.Business;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Repositories.FiniteScheduler.Business
{
    public interface Itbl_KnittingRollsRepository : IGenericRepository<tbl_KnittingRolls>
    {
        //Task<RResult> SaveTemporaryGateReceiving(List<tbl_KnittingRollsViewModel> KnittingRolls, int JobId, int createdBy, bool saveChanges = true);
        //Task<List<tbl_KnittingRollsViewModel>> GetKnittingRollsByJobId(int jobId);
        //Task<List<tbl_KnittingRollsViewModel>> GetKnittingRollsForInspection(List<tbl_KnittingRollsViewModel> rollList);
        //Task<List<tbl_KnittingRollsViewModel>> GetKnittingRollsForInspection(int jobID);
        //Task<List<SelectListItem>> DDLRollsForPermanentReceivingByYKNC(long YKNCId);
        //Task<List<tbl_KnittingStockTransactionViewModel>> GetKnittingRollsDetailSpecification(List<PassingString> rollCodeList);
        //Task<CommonDataPass> GetKnitterCompanyIdByRollCode(string rollCode);
        //Task<RResult> UpdateWihlePermanentReceiving(List<Greige_StockTransactionsViewModel> greigeStockTransactions, int createdBy);
    }
}