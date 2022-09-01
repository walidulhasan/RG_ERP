using RG.Application.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Repositories.AlgoHR.Business
{
    public interface ISchedulerTaskRepository
    {
        Task<RResult> ModifyAttendanceByShortLeaveAndOutsideDuty(CancellationToken cancellationToken); 
    }
}
