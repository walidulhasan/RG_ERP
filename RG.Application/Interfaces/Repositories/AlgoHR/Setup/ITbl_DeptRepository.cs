using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Common.Utilities;
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
    public interface ITbl_DeptRepository : IGenericRepository<Tbl_Dept>
    {
        Task<List<SelectListItem>> DDLDept(int divisionID,CancellationToken cancellationToken=default);
        Task<List<SelectListItem>> DDLDept(List<int> divisionID, string Predict = null, CancellationToken cancellationToken = default);
        Task<List<SelectListItem>> DDLDeptListOnly(CancellationToken cancellationToken);
        Task<List<IdNamePairRM>> DDLDepartmentLookup(List<int> divisionID, string Predict = null, CancellationToken cancellationToken = default);
    }
}
