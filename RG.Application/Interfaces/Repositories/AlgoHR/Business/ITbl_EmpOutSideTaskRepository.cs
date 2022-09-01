using RG.Application.Common.Models;
using RG.DBEntities.AlgoHR.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Repositories.AlgoHR.Business
{
    public interface ITbl_EmpOutSideTaskRepository :IGenericRepository<Tbl_EmpOutSideTask>
    {
        Task<RResult> SaveTbl_EmpOutSideTask(Tbl_EmpOutSideTask entity, bool saveChange = true);
        Task<RResult> UpdateTbl_EmpOutSideTask(Tbl_EmpOutSideTask entity, bool saveChange = true);
    }
}
