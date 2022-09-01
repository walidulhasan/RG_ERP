using MediatR;
using RG.Application.Common.Models;
using RG.Application.Interfaces.Services.AlgoHR.Business;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.AlgoHR.Business.SchedulerTasks.Commands.Update
{
    public class ModifyAttendanceByShortLeaveAndOutsideDutyCommand : IRequest<RResult>
    {
    }
    public class ModifyAttendanceByShortLeaveAndOutsideDutyCommandHandler : IRequestHandler<ModifyAttendanceByShortLeaveAndOutsideDutyCommand, RResult>
    {
        private readonly ISchedulerTaskService _schedulerTaskService;

        public ModifyAttendanceByShortLeaveAndOutsideDutyCommandHandler(ISchedulerTaskService schedulerTaskService)
        {
            _schedulerTaskService = schedulerTaskService;
        }
        public async Task<RResult> Handle(ModifyAttendanceByShortLeaveAndOutsideDutyCommand request, CancellationToken cancellationToken)
        {
            return await _schedulerTaskService.ModifyAttendanceByShortLeaveAndOutsideDuty(cancellationToken);
        }
    }
}
