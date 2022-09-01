using RG.Application.Contracts.AlgoHR.Business.CalenderEventDetail.Queries.RequestResponseModel;
using RG.DBEntities.AlgoHR.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Repositories.AlgoHR.Business
{
    public interface ICalenderEventDetailsRepository : IGenericRepository<CalenderEventDetails>
    {
        Task<List<GetAllCalenderEventDetailsRM>> GetAllCalenderEventDetail(GetAllCalenderEventDetailsQM qm, CancellationToken cancellationToken);
    }
}
