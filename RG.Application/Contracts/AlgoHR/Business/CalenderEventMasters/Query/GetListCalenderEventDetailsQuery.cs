using MediatR;
using RG.Application.Contracts.AlgoHR.Business.CalenderEventMasters.Query.RequestResponseModel;
using RG.Application.Interfaces.Services.AlgoHR.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.AlgoHR.Business.CalenderEventMasters.Query
{
    public class GetListCalenderEventDetailsQuery:IRequest<List<CalenderEventDetailsRM>>
    {
        public DateTime scheduleDate { get; set; }
    }
    public class GetListCalenderEventDetailsQueryHandler : IRequestHandler<GetListCalenderEventDetailsQuery, List<CalenderEventDetailsRM>>
    {
        private readonly ICalenderEventMasterService _calenderEventMasterService;

        public GetListCalenderEventDetailsQueryHandler(ICalenderEventMasterService calenderEventMasterService)
        {
            _calenderEventMasterService = calenderEventMasterService;
        }
        public async Task<List<CalenderEventDetailsRM>> Handle(GetListCalenderEventDetailsQuery request, CancellationToken cancellationToken)
        {
           return await _calenderEventMasterService.GetListCalenderEventDetails(request.scheduleDate,cancellationToken);
        }
    }
}
