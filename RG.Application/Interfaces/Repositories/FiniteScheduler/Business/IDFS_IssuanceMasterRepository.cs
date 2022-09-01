using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Common.Models;
using RG.DBEntities.FiniteScheduler.Business;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Repositories.FiniteScheduler.Business
{
   public interface IDFS_IssuanceMasterRepository :IGenericRepository<DFS_IssuanceMaster>
    {
        //Task<List<DyeingIssuance_ChallansViewModel>> Get_All_DyeingIssuance_Challans(DateTime? DateFrom=null,DateTime? DateTo=null);
        //Task<DyeingRollDetailsViewModel> Get_Dyeing_Roll_details_On_ChallanID(long IssuanceID);
        Task<RResult> UpdateReceivedStatus(long IssuanceID,bool ReceivedStatus, int CreateBy);
        Task<List<SelectListItem>> DDLLotListForIssuance();
        Task<List<SelectListItem>> DDLDCListForIssuance(int LotId);
        Task<string> GetLotDetailForIssuance(int lotId);
        //Task<RResult> SaveDFS_IssuanceMaster(DFS_IssuanceMasterViewModel lotIssuanceMaster, int session_EMPLOYEE_ID, bool saveChanges = true);
    }
}
