
using RG.Application.Common.Models;
using RG.DBEntities.FiniteScheduler.Business;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Repositories.FiniteScheduler.Business
{
    
    public interface IDFS_InspectionMasterRepository:IGenericRepository<DFS_InspectionMaster>
    {
        //Task<RResult> SaveDFS_InspectionMaster(DFS_InspectionMasterViewModel dfsLotInspectionMaster, int createdBy, bool saveChanges = true);
    }
}
