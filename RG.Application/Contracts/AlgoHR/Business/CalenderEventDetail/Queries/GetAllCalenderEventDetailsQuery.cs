using MediatR;
using RG.Application.Contracts.AlgoHR.Business.CalenderEventDetail.Queries.RequestResponseModel;
using RG.Application.Interfaces.Services.AlgoHR.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.AlgoHR.Business.CalenderEventDetail.Queries
{
    public class GetAllCalenderEventDetailsQuery:IRequest<List<GetAllCalenderEventDetailsRM>>
    {
        public GetAllCalenderEventDetailsQM queryModel { get; set; }
    }
    public class GetAllCalenderEventDetailsHandler : IRequestHandler<GetAllCalenderEventDetailsQuery, List<GetAllCalenderEventDetailsRM>>
    {
        private readonly ICalenderEventDetailsService _calenderEventDetailsService;

        public GetAllCalenderEventDetailsHandler(ICalenderEventDetailsService calenderEventDetailsService )
        {
            _calenderEventDetailsService = calenderEventDetailsService;
        }
        public async Task<List<GetAllCalenderEventDetailsRM>> Handle(GetAllCalenderEventDetailsQuery request, CancellationToken cancellationToken)
        {
            return await _calenderEventDetailsService.GetAllCalenderEventDetail(request.queryModel,cancellationToken);
        }
    }
}
