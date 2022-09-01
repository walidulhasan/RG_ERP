using MediatR;
using RG.Application.Common.Models;
using RG.Application.Interfaces.Services.AlgoHR.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.AlgoHR.Business.CalenderEventMasters.Commands.Update
{
    public class CalenderEventDetailsRemove:IRequest<RResult>
    {
        public int id { get; set; }
    }
    public class CalenderEventDetailsRemoveHandler : IRequestHandler<CalenderEventDetailsRemove, RResult>
    {
        private readonly ICalenderEventMasterService _calenderEventMasterService;

        public CalenderEventDetailsRemoveHandler(ICalenderEventMasterService calenderEventMasterService)
        {
            _calenderEventMasterService = calenderEventMasterService;
        }
        public async Task<RResult> Handle(CalenderEventDetailsRemove request, CancellationToken cancellationToken)
        {
            return await _calenderEventMasterService.CalenderEventDetailsRemove(request.id,true);
        }
    }
}
