using MediatR;
using RG.Application.Interfaces.Services.AlgoHR.Business;
using RG.DBEntities.AlgoHR.DBViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.AlgoHR.Business.Tbl_EmpLeavess.Query
{
    public class GetEmpLeaveInfoQuery:IRequest<Vw_EmpLeaves>
    {
        public int id { get; set; }
    }
    public class GetEmpLeaveInfoQueryHandler : IRequestHandler<GetEmpLeaveInfoQuery,Vw_EmpLeaves>
    {
        private readonly ITbl_EmpLeavesService _tbl_EmpLeavesService;

        public GetEmpLeaveInfoQueryHandler(ITbl_EmpLeavesService tbl_EmpLeavesService)
        {
            _tbl_EmpLeavesService = tbl_EmpLeavesService;
        }

        public async Task<Vw_EmpLeaves> Handle(GetEmpLeaveInfoQuery request, CancellationToken cancellationToken)
        {
            return await _tbl_EmpLeavesService.GetEmpLeaveInfo(request.id, cancellationToken);
        }
    }
}
