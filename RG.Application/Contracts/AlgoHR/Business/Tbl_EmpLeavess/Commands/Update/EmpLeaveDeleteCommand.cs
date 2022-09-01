using MediatR;
using RG.Application.Common.Models;
using RG.Application.Interfaces.Services.AlgoHR.Business;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.AlgoHR.Business.Tbl_EmpLeavess.Commands.Update
{
    public class EmpLeaveDeleteCommand : IRequest<RResult>
    {
        public int ID { get; set; }
        public int LeaveTypeID { get; set; }
    }
    public class EmpLeaveDeleteCommandHandler : IRequestHandler<EmpLeaveDeleteCommand, RResult>
    {
        private readonly ITbl_EmpLeavesService _tbl_EmpLeavesService;

        public EmpLeaveDeleteCommandHandler(ITbl_EmpLeavesService tbl_EmpLeavesService)
        {
            _tbl_EmpLeavesService = tbl_EmpLeavesService;
        }
        public async Task<RResult> Handle(EmpLeaveDeleteCommand request, CancellationToken cancellationToken)
        {
            return await _tbl_EmpLeavesService.DeleteTbl_EmpLeaves(request.ID,request.LeaveTypeID, true);
        }
    }
}
