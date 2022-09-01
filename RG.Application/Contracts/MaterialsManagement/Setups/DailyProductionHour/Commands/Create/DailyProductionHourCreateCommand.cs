using MediatR;
using RG.Application.Common.Models;
using RG.Application.Contracts.MaterialsManagement.Setups.DailyProductionHour.Commands.DataTransferModel;
using RG.Application.Interfaces.Services.MaterialsManagement.Setups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.MaterialsManagement.Setups.DailyProductionHour.Commands.Create
{
    public class DailyProductionHourCreateCommand:IRequest<RResult>
    {
        public DailyProductionHourDTM DailyProductionHour { get; set; }
    }
    public class DailyProductionHourCreateCommandHandler : IRequestHandler<DailyProductionHourCreateCommand, RResult>
    {
        private readonly IDailyProductionHourService _dailyProductionHourService;

        public DailyProductionHourCreateCommandHandler(IDailyProductionHourService dailyProductionHourService)
        {
            _dailyProductionHourService = dailyProductionHourService;
        }
        public async Task<RResult> Handle(DailyProductionHourCreateCommand request, CancellationToken cancellationToken)
        {
            return await _dailyProductionHourService.SaveAndUpdate(request.DailyProductionHour);
        }
    }
}
