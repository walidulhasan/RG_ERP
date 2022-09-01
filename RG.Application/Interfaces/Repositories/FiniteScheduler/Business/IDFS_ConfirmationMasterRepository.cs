 
using RG.Application.Common.Models;
using RG.DBEntities.FiniteScheduler.Business;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Repositories.FiniteScheduler.Business
{
    public interface IDFS_ConfirmationMasterRepository:IGenericRepository<DFS_ConfirmationMaster>
    {
        //Task<RResult> SaveDFS_ConfirmationMaster(DFS_ConfirmationMasterViewModel ConfirmationMaster, int createdBy, bool saveChanges = true);
    }
}
