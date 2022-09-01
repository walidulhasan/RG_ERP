using FluentValidation;
using RG.Application.Contracts.MaterialsManagement.Setups.DailyProductionHour.Commands.DataTransferModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Contracts.MaterialsManagement.Setups.DailyProductionHour.Commands.Create
{
    public class DailyProductionHourCreateCommandValidator : AbstractValidator<DailyProductionHourCreateCommand>
    {
        public DailyProductionHourCreateCommandValidator()
        {
            RuleFor(b => b.DailyProductionHour).SetValidator(new DailyProductionHourDTMValidator());
        }
    }
}
