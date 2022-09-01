using RG.Application.Common.Models;
using RG.Application.Interfaces.Repositories.AlgoHR.Business;
using RG.Application.Interfaces.Services.AlgoHR.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Services.AlgoHR.Business
{
    public class SchedulerTaskService : ISchedulerTaskService
    {
        private readonly ISchedulerTaskRepository _schedulerTaskRepository;
        public SchedulerTaskService(ISchedulerTaskRepository schedulerTaskRepository)
        {
            _schedulerTaskRepository = schedulerTaskRepository;
        }
        public async Task<RResult> ModifyAttendanceByShortLeaveAndOutsideDuty(CancellationToken cancellationToken=default)
        {
            return await _schedulerTaskRepository.ModifyAttendanceByShortLeaveAndOutsideDuty(cancellationToken);
        }
    }
}
