using RG.Application.Contracts.AlgoHR.Business.CalenderEventDetail.Queries.RequestResponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Services.AlgoHR.Business
{
    public  interface ICalenderEventDetailsService
    {
        Task<List<GetAllCalenderEventDetailsRM>> GetAllCalenderEventDetail(GetAllCalenderEventDetailsQM qm, CancellationToken cancellationToken);
    }
}
