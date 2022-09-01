
using RG.Application.Common.Models;
using RG.DBEntities.FiniteScheduler.Business;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Repositories.FiniteScheduler.Business
{
    public interface IDFS_Return_RollsRepository:IGenericRepository<DFS_Return_Rolls>
    {
        //Task<RResult> SaveDFS_Return_RollsList(List<DFS_Return_RollsViewModel> dFS_Return_Rolls, int createdBy);
    }
}
