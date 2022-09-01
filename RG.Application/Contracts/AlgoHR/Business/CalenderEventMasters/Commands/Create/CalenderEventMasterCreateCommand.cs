using MediatR;
using RG.Application.Common.Models;
using RG.Application.Contracts.AlgoHR.Business.CalenderEventMasters.Commands.DataTransferModel;
using RG.Application.Interfaces.Services.AlgoHR.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.AlgoHR.Business.CalenderEventMasters.Commands.Create
{
    public class CalenderEventMasterCreateCommand : IRequest<RResult>
    {
        public CalenderEventMastersDTM dtModel { get; set; }
    }
    public class CalenderEventMasterCreateCommandHandler : IRequestHandler<CalenderEventMasterCreateCommand, RResult>
    {
        private readonly ICalenderEventMasterService _calenderEventMasterService;

        public CalenderEventMasterCreateCommandHandler(ICalenderEventMasterService calenderEventMasterService)
        {
            _calenderEventMasterService = calenderEventMasterService;
        }
        public async Task<RResult> Handle(CalenderEventMasterCreateCommand request, CancellationToken cancellationToken)
        {
            return await _calenderEventMasterService.CalenderEventMasterCreate(request.dtModel,true);
        }
    }
}
