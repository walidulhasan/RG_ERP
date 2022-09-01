using RG.Application.Common.Models;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Services.AlgoHR.Business
{
    public interface ISchedulerTaskService
    {
        Task<RResult> ModifyAttendanceByShortLeaveAndOutsideDuty(CancellationToken cancellationToken=default);

    }
}
