using RG.Application.Contracts.AlgoHR.Business.CalenderEventDetail.Queries.RequestResponseModel;
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
    public class CalenderEventDetailsService : ICalenderEventDetailsService
    {
        private readonly ICalenderEventDetailsRepository _calenderEventDetailsRepository;

        public CalenderEventDetailsService(ICalenderEventDetailsRepository calenderEventDetailsRepository)
        {
            _calenderEventDetailsRepository = calenderEventDetailsRepository;
        }
        public async Task<List<GetAllCalenderEventDetailsRM>> GetAllCalenderEventDetail(GetAllCalenderEventDetailsQM qm, CancellationToken cancellationToken)
        {
            return await _calenderEventDetailsRepository.GetAllCalenderEventDetail(qm,cancellationToken);
        }
    }
}
