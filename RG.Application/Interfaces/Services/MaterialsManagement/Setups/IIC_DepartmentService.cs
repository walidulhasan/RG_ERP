using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Contracts.MaterialsManagement.Setups.IC_Departments.Queries.RequestResponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Services.MaterialsManagement.Setups
{
    public interface IIC_DepartmentService
    {
        Task<List<SelectListItem>> DDLGetDepartmentByUserID(int userID, CancellationToken cancellationToken);
        Task<List<SelectListItem>> DDLGetDepartmentList(CancellationToken cancellationToken, int ID = 0);
        Task<IC_DepartmentRM> GetDepartmentInfo(long DepartmentID, CancellationToken cancellationToken);
    }
}
