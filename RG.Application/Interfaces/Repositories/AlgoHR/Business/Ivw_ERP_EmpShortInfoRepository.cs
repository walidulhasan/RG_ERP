using Microsoft.AspNetCore.Mvc.Rendering;
using RG.DBEntities.AlgoHR.DBViews;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Repositories.AlgoHR.Business
{
    public interface Ivw_ERP_EmpShortInfoRepository : IGenericRepository<vw_ERP_EmpShortInfo>
    {
        Task<List<SelectListItem>> DDLEmployeeList(string predict = null, CancellationToken cancellationToken=default);
        Task<List<SelectListItem>> DDLEmployeeList(int companyID, int officeDivisionID, int departmentID, int sectionID, int designationID, string predict = null, CancellationToken cancellationToken = default);
        Task<vw_ERP_EmpShortInfo> Get_ERP_EmpShortInfo(string empCode = null, long? employeeID = 0, CancellationToken cancellationToken = default);
    }
}
