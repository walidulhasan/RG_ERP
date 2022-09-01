using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Common.Models;
using RG.DBEntities.FiniteScheduler.Business;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Repositories.FiniteScheduler.Business
{
   public interface Itbl_KnittingJobsRepository:IGenericRepository<tbl_KnittingJobs>
    {
        //Task<List<SelectListItem>> DDLKnittingJobsByYKNC(long ykncId);
        //Task<tbl_KnittingJobsViewModel> GetKnittingJobMachineAssociate(int jobId);
        //Task<tbl_KnittingJobsViewModel> GetKnittingJobByYKNCId(long ykncId);
        //Task<RResult> tbl_KnittingJobsSave(tbl_KnittingJobs entity);
        //Task<RResult> Updatetbl_KnittingJobsStatusToCompleted(int jobId);
    }
}
