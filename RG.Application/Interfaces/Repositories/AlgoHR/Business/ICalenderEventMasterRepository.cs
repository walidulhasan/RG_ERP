using RG.Application.Common.Models;
using RG.Application.Contracts.AlgoHR.Business.CalenderEventMasters.Commands.DataTransferModel;
using RG.Application.Contracts.AlgoHR.Business.CalenderEventMasters.Query.RequestResponseModel;
using RG.DBEntities.AlgoHR.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Repositories.AlgoHR.Business
{
    public  interface ICalenderEventMasterRepository : IGenericRepository<CalenderEventMaster>
    {
        Task<List<CalenderEventDetailsRM>> GetListCalenderEventDetails(DateTime ScheduleDate, CancellationToken cancellationToken);
    }
}
