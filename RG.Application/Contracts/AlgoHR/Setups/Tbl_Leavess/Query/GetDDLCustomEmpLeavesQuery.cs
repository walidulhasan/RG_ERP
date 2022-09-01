using MediatR;
using RG.Application.Common.Models;
using RG.Application.Interfaces.Services.AlgoHR.Setup;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.AlgoHR.Setups.Tbl_Leavess.Query
{
    public class GetDDLCustomEmpLeavesQuery : IRequest<List<DropDownItem>>
    {
        public int EmployeeID { get; set; }
        public string EmployeeCode { get; set; }
    }
    public class GetDDLCustomEmpLeavesQueryHandler : IRequestHandler<GetDDLCustomEmpLeavesQuery, List<DropDownItem>>
    {
        private readonly ITbl_LeavesService tbl_LeavesService;

        public GetDDLCustomEmpLeavesQueryHandler(ITbl_LeavesService _tbl_LeavesService)
        {
            tbl_LeavesService = _tbl_LeavesService;
        }
        public async Task<List<DropDownItem>> Handle(GetDDLCustomEmpLeavesQuery request, CancellationToken cancellationToken)
        {
            return await tbl_LeavesService.DDLCustomEmpLeaves(request.EmployeeID, request.EmployeeCode, cancellationToken);
        }
    }
}
