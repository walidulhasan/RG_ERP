using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Common.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Services.AlgoHR.Setup
{
    public interface ITbl_DeptService
    {
        Task<List<SelectListItem>> DDLDept(int divisionID,CancellationToken cancellationToken=default);
        Task<List<SelectListItem>> DDLDept(List<int>divisionID,string Predict=null, CancellationToken cancellationToken = default);
        Task<List<IdNamePairRM>> DDLDepartmentLookup(List<int> divisionID, string Predict = null, CancellationToken cancellationToken = default);
        Task<List<SelectListItem>> DDLDeptListOnly(CancellationToken cancellationToken);
    }
}
