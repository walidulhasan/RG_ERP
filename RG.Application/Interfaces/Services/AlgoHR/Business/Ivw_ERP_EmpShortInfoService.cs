using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Contracts.AlgoHR.Business.Tbl_Emp.Query.RequestResponseModel;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Services.AlgoHR.Business
{
    public interface Ivw_ERP_EmpShortInfoService
    {
        Task<List<SelectListItem>> DDLEmployeeList(string predict = null, CancellationToken cancellationToken = default);
        Task<List<SelectListItem>> DDLEmployeeList(int companyID, int officeDivisionID, int departmentID, int sectionID, int designationID, string predict = null, CancellationToken cancellationToken = default);
        Task<vw_ERP_EmpShortInfoRM> Get_ERP_EmpShortInfo(string empCode = null, long? employeeID = 0, CancellationToken cancellationToken = default);
    }
}
