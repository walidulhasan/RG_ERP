using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Common.Models;
using RG.DBEntities.FiniteScheduler.Business;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Repositories.FiniteScheduler.Business
{
   public interface IDFS_LotMakingMasterRepository:IGenericRepository<DFS_LotMakingMaster>
    {
         //Task<RResult> SaveDFSLotMakingMaster(DFS_LotMakingMasterViewModel dfsLotMakingMaster, int createdBy, bool saveChanges = true);
        Task<List<SelectListItem>> DDLLotListForConfirmation();
        Task<string> GetLotDetailForConfirmation(int lotId);
        Task<string> GetLotDetailForInspection(int lotId);
        //Task<RResult> UpdateDuringLotConfirmation(DFS_LotMakingMasterViewModel lotMakingMaster, int createdBy, bool saveChanges);
        Task<List<SelectListItem>> DDLLotListForInspection();
        Task<List<SelectListItem>> DDLLotListByDCID(long dcid);
        Task<bool> IsDuplicateLot(string lotNo);
    }
}
