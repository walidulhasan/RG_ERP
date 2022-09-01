using MediatR;
using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Interfaces.Services.AlgoHR.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.AlgoHR.Setups.Tbl_Depts.Query
{
    public class DDLDeptListOnlyQuery:IRequest<List<SelectListItem>>
    {
    }
    public class DDLDeptListOnlyQueryHandler : IRequestHandler<DDLDeptListOnlyQuery, List<SelectListItem>>
    {
        private readonly ITbl_DeptService _tbl_DeptService;

        public DDLDeptListOnlyQueryHandler(ITbl_DeptService tbl_DeptService)
        {
            _tbl_DeptService = tbl_DeptService;
        }
        public async Task<List<SelectListItem>> Handle(DDLDeptListOnlyQuery request, CancellationToken cancellationToken)
        {
            return await _tbl_DeptService.DDLDeptListOnly(cancellationToken);
        }
    }
}
