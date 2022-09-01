using MediatR;
using RG.Application.Common.Models;
using RG.Application.Contracts.AlgoHR.Tbl_EmpLeavess.Commands.DataTransferModel;
using RG.Application.Interfaces.Services.AlgoHR.Business;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.AlgoHR.Tbl_EmpLeavess.Commands.Create
{
    public class EmpLeaveCreateCommand : IRequest<RResult>
    {
        public EmpLeaveDTM EmpLeave { get; set; }
    }
    public class EmpLeaveCreateCommandHandler : IRequestHandler<EmpLeaveCreateCommand, RResult>
    {
        private readonly ITbl_EmpLeavesService tbl_EmpLeavesService;

        public EmpLeaveCreateCommandHandler(ITbl_EmpLeavesService _tbl_EmpLeavesService)
        {
            tbl_EmpLeavesService = _tbl_EmpLeavesService;
        }
        public async Task<RResult> Handle(EmpLeaveCreateCommand request, CancellationToken cancellationToken)
        {

            return await tbl_EmpLeavesService.SaveTbl_EmpLeaves(request.EmpLeave, true);
        }
    }
}
