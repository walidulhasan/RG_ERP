using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Common.Models;
using RG.Application.Contracts.AlgoHR.Business.Tbl_Emp.Query.RequestResponseModel;
using RG.DBEntities.AlgoHR.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Repositories.AlgoHR.Setup
{
    public interface IUserDepartmentAccessRepository : IGenericRepository<UserDepartmentAccess>
    {
        Task<RResult> SaveUserDepartmentAccess(List<UserDepartmentAccess> entities);
        Task<List<SelectListItem>> DDLUserCompany(int UserID, bool IsAll = false, CancellationToken cancellationToken = default);
        Task<List<SelectListItem>> DDLUserDivision(int UserID, List<int> CompanyID, bool IsAll = false, string Predict=null, CancellationToken cancellationToken = default);
        Task<List<SelectListItem>> DDLUserDepartment(int UserID, List<int> CompanyID, List<int>DivisionID, bool IsAll = false, string Predict = null, CancellationToken cancellationToken = default);
        Task<List<SelectListItem>> DDLUserSection(int UserID, List<int> CompanyID , List<int> DivisionID, List<int> DepartmentID , bool IsAll = false, string Predict = null, CancellationToken cancellationToken = default);
        Task<List<SelectListItem>> DDLUserSectionEmployee(int UserID, List<int> CompanyID, List<int> DivisionID, List<int> DepartmentID, List<int> SectionID
             ,List<int> Designations, List<int> Locations, int? EmployeeTypes = null, string Gender = null, bool? ActiveStatus = null
            , string Predit = null, bool IsAll = false, CancellationToken cancellationToken = default);
        IQueryable<EmployeeToSectionRM> GetUserDepartmentAccessList(int UserID=0);

    }
}
