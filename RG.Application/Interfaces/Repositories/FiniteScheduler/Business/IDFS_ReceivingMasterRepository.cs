
using RG.DBEntities.FiniteScheduler.Business;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Repositories.FiniteScheduler.Business
{
  public  interface IDFS_ReceivingMasterRepository:IGenericRepository<DFS_ReceivingMaster>
    {
        //Task<RResult> SaveDFSReceivingMaster(DFS_ReceivingMasterViewModel dfsReceivingMaster, int createdBy, bool saveChanges = true);
    }
}
