using MediatR;
using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Interfaces.Services.AlgoHR.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.AlgoHR.Setups.Tbl_Leavess.Query
{
    public class GetDDLComplimentaryLeaveQuery:IRequest<List<SelectListItem>>
    {
        public int EmployeeID { get; set; }
    }
    public class GetDDLComplimentaryLeaveQueryHandller : IRequestHandler<GetDDLComplimentaryLeaveQuery, List<SelectListItem>>
    {
        private readonly ITbl_LeavesService _tbl_LeavesService;

        public GetDDLComplimentaryLeaveQueryHandller(ITbl_LeavesService tbl_LeavesService)
        {
            _tbl_LeavesService = tbl_LeavesService;
        }
        public async Task<List<SelectListItem>> Handle(GetDDLComplimentaryLeaveQuery request, CancellationToken cancellationToken)
        {
            return await _tbl_LeavesService.GetDDLComplimentaryLeave(request.EmployeeID,cancellationToken);
        }
    }
}
