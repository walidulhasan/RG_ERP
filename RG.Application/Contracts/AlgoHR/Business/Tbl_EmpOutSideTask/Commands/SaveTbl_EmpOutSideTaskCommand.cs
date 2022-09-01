using MediatR;
using RG.Application.Common.Models;
using RG.Application.Contracts.AlgoHR.Business.Tbl_EmpOutSideTask.Commands.DataTransferModel;
using RG.Application.Interfaces.Services.AlgoHR.Business;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.AlgoHR.Business.Tbl_EmpOutSideTask.Commands
{
    public class SaveTbl_EmpOutSideTaskCommand : IRequest<RResult>
    {
        public OutsideDutyApplicationDTM OutsideDuty { get; set; }
    }
    public class SaveTbl_EmpOutSideTaskCommandHandler : IRequestHandler<SaveTbl_EmpOutSideTaskCommand, RResult>
    {
        private readonly ITbl_EmpOutSideTaskService tbl_EmpOutSideTaskService;

        public SaveTbl_EmpOutSideTaskCommandHandler(ITbl_EmpOutSideTaskService _tbl_EmpOutSideTaskService)
        {
            tbl_EmpOutSideTaskService = _tbl_EmpOutSideTaskService;
        }
        public async Task<RResult> Handle(SaveTbl_EmpOutSideTaskCommand request, CancellationToken cancellationToken)
        {
            return await tbl_EmpOutSideTaskService.SaveTbl_EmpOutSideTask(request.OutsideDuty);
        }
    }
}
