using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Common.Utilities;
using RG.Application.Interfaces.Repositories.AlgoHR.Setup;
using RG.Application.Interfaces.Services.AlgoHR.Setup;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Services.AlgoHR.Setup
{
    public class Tbl_DeptService : ITbl_DeptService
    {
        private readonly ITbl_DeptRepository _tbl_DeptRepository;

        public Tbl_DeptService(ITbl_DeptRepository tbl_DeptRepository)
        {
            _tbl_DeptRepository = tbl_DeptRepository;
        }

        public async Task<List<IdNamePairRM>> DDLDepartmentLookup(List<int> divisionID, string Predict = null, CancellationToken cancellationToken = default)
        {
            return await _tbl_DeptRepository.DDLDepartmentLookup(divisionID, Predict, cancellationToken);
        }

        public async Task<List<SelectListItem>> DDLDept(int divisionID, CancellationToken cancellationToken = default)
        {
            return await _tbl_DeptRepository.DDLDept(divisionID, cancellationToken);
        }

        public async Task<List<SelectListItem>> DDLDept(List<int> divisionID, string Predict = null, CancellationToken cancellationToken = default)
        {
            return await _tbl_DeptRepository.DDLDept(divisionID, Predict, cancellationToken);
        }

        public async Task<List<SelectListItem>> DDLDeptListOnly(CancellationToken cancellationToken)
        {
            return await _tbl_DeptRepository.DDLDeptListOnly(cancellationToken);
        }
    }
}
