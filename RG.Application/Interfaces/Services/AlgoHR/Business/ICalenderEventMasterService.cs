using RG.Application.Common.Models;
using RG.Application.Contracts.AlgoHR.Business.CalenderEventMasters.Commands.DataTransferModel;
using RG.Application.Contracts.AlgoHR.Business.CalenderEventMasters.Query.RequestResponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Services.AlgoHR.Business
{
    public interface ICalenderEventMasterService
    {
        Task<RResult> CalenderEventMasterCreate(CalenderEventMastersDTM model, bool saveChange = true);
        Task<List<CalenderEventDetailsRM>> GetListCalenderEventDetails(DateTime ScheduleDate, CancellationToken cancellationToken);
        Task<RResult> CalenderEventDetailsRemove(int id, bool saveChange);
    }
}
