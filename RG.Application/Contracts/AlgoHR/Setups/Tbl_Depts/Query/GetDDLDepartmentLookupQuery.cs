using MediatR;
using RG.Application.Common.Utilities;
using RG.Application.Interfaces.Services.AlgoHR.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.AlgoHR.Setups.Tbl_Depts.Query
{
    public class GetDDLDepartmentLookupQuery : IRequest<List<IdNamePairRM>>
    {
        public List<int> DivisionID { get; set; }
        public string Predict { get; set; } = null;
    }

    public class GetDDLDepartmentLookupQueryHandler : IRequestHandler<GetDDLDepartmentLookupQuery, List<IdNamePairRM>>
    {
        private readonly ITbl_DeptService _tbl_DeptService;

        public GetDDLDepartmentLookupQueryHandler(ITbl_DeptService tbl_DeptService)
        {
            _tbl_DeptService = tbl_DeptService;
        }
        public async Task<List<IdNamePairRM>> Handle(GetDDLDepartmentLookupQuery request, CancellationToken cancellationToken)
        {
            return await _tbl_DeptService.DDLDepartmentLookup(request.DivisionID,request.Predict,cancellationToken); 
        }
    }
}
