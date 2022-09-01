using MediatR;
using RG.Application.Common.Models;
using RG.Application.Interfaces.Services.MaterialsManagement.Setups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.MaterialsManagement.Setups.DailyProductionHour.Commands.Update
{
    public class DailyProductionHourRemoveCommand:IRequest<RResult>
    {
        public int id { get; set; }
    }
    public class DailyProductionHourRemoveCommandHandler : IRequestHandler<DailyProductionHourRemoveCommand, RResult>
    {
        private readonly IDailyProductionHourService _dailyProductionHourService;

        public DailyProductionHourRemoveCommandHandler(IDailyProductionHourService dailyProductionHourService)
        {
            _dailyProductionHourService = dailyProductionHourService;
        }
        public async Task<RResult> Handle(DailyProductionHourRemoveCommand request, CancellationToken cancellationToken)
        {
            return await _dailyProductionHourService.Remove(request.id, true);
        }
    }
}
