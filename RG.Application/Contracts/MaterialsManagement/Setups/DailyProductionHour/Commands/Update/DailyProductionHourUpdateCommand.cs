using MediatR;
using RG.Application.Common.Models;
using RG.Application.Contracts.MaterialsManagement.Setups.DailyProductionHour.Commands.DataTransferModel;
using RG.Application.Interfaces.Services.MaterialsManagement.Setups;
using RG.Application.ViewModel.MaterialsManagement.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.MaterialsManagement.Setups.DailyProductionHour.Commands.Update
{
    public class DailyProductionHourUpdateCommand:IRequest<RResult>
    {
        public DailyProductionHourDTM DailyProductionHour { get; set; }
        public bool SaveChange { get; set; }
    }
    public class DailyProductionHourUpdateCommandHandler : IRequestHandler<DailyProductionHourUpdateCommand, RResult>
    {
        private readonly IDailyProductionHourService _dailyProductionHourService;

        public DailyProductionHourUpdateCommandHandler(IDailyProductionHourService dailyProductionHourService)
        {
            _dailyProductionHourService = dailyProductionHourService;
        }
        public async Task<RResult> Handle(DailyProductionHourUpdateCommand request, CancellationToken cancellationToken)
        {
            return await _dailyProductionHourService.SaveAndUpdate(request.DailyProductionHour);
        }
    }
}
