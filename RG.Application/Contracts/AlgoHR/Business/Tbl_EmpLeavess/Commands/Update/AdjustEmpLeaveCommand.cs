using MediatR;
using RG.Application.Common.Models;
using RG.Application.Interfaces.Services.AlgoHR.Business;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.AlgoHR.Business.Tbl_EmpLeavess.Commands.Update
{
    public class AdjustEmpLeaveCommand : IRequest<RResult>
    {
        public int LeaveID { get; set; }
        public DateTime AdjustedDateFrom { get; set; }
        public DateTime AdjustedDateTo { get; set; }
    }
    public class AdjustEmpLeaveCommandHandler : IRequestHandler<AdjustEmpLeaveCommand, RResult>
    {
        private readonly ITbl_EmpLeavesService _tbl_EmpLeavesService;

        public AdjustEmpLeaveCommandHandler(ITbl_EmpLeavesService tbl_EmpLeavesService)
        {
            _tbl_EmpLeavesService = tbl_EmpLeavesService;
        }
        public async Task<RResult> Handle(AdjustEmpLeaveCommand request, CancellationToken cancellationToken)
        {
            return await _tbl_EmpLeavesService.AdjustTbl_EmpLeaves(request.LeaveID, request.AdjustedDateFrom, request.AdjustedDateTo, true);
        }
    }
}
