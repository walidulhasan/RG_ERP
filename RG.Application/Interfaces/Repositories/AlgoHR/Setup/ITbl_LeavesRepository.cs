using Microsoft.AspNetCore.Mvc.Rendering;
using RG.DBEntities.AlgoHR;
using RG.DBEntities.AlgoHR.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Repositories.AlgoHR.Setup
{
    public interface ITbl_LeavesRepository:IGenericRepository<Tbl_Leaves>
    {
        Task<List<SelectListItem>> DDLLeaves(CancellationToken cancellationToken);
        Task<List<SelectListItem>> GetDDLComplimentaryLeave(long employeeID, CancellationToken cancellationToken);
    }
}
