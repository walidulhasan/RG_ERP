using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Common.Models;
using RG.Application.Contracts.AlgoHR.Setups.Tbl_Leavess.Query.RequestResponseModel;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Services.AlgoHR.Setup
{
    public interface ITbl_LeavesService
    {
        Task<List<SelectListItem>> DDLLeaves( CancellationToken cancellationToken);
        Task<List<DropDownItem>> DDLCustomEmpLeaves(int employeeID, string employeeCode, CancellationToken cancellationToken);
        Task<List<Tbl_LeavesRM>> GetEmployeeWiseLeaves(int employeeID, CancellationToken cancellationToken);
        Task<List<SelectListItem>> GetDDLComplimentaryLeave(long employeeID, CancellationToken cancellationToken);
    }
}
