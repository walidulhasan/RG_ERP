using AutoMapper;
using FluentValidation;
using RG.Application.Common.Mappings;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Contracts.MaterialsManagement.Setups.DailyProductionHour.Commands.DataTransferModel
{
    public class DailyProductionHourDTM : IMapFrom<DBEntities.MaterialsManagement.Setup.DailyProductionHour>
    {
        public int ID { get; set; }
        public string ProductionType { get; set; }
        public decimal TimeFrom { get; set; }
        public decimal TimeTo { get; set; }
        public decimal LapTiming { get; set; }
        public string Description { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<DailyProductionHourDTM, DBEntities.MaterialsManagement.Setup.DailyProductionHour>();
        }
    }

    public class DailyProductionHourDTMValidator : AbstractValidator<DailyProductionHourDTM>
    {
        public DailyProductionHourDTMValidator()
        {
            RuleFor(b => b.ProductionType).NotNull().WithMessage("Production Type is required.");

            RuleFor(b => b.TimeFrom).NotNull().WithMessage("Time from is required.");
            RuleFor(b => b.TimeFrom).GreaterThanOrEqualTo(1).WithMessage("Time from must be less than 13.");
            RuleFor(b => b.TimeFrom).LessThanOrEqualTo(13).WithMessage("Time from must be grether than 0.");

            RuleFor(b => b.TimeTo).NotNull().WithMessage("Time to is required.");
            RuleFor(b => b.TimeTo).GreaterThanOrEqualTo(1).WithMessage("Time to must be less than 13. ");
            RuleFor(b => b.TimeTo).LessThanOrEqualTo(13).WithMessage("Time to must be grether than 0.");
            
            RuleFor(b => b.LapTiming).NotNull().WithMessage("Lap timing is required.");
            RuleFor(b => b.LapTiming).GreaterThanOrEqualTo(1).WithMessage("Lap timing to must be less than 13. ");
            RuleFor(b => b.LapTiming).LessThanOrEqualTo(13).WithMessage("Lap timing must be grether than 0.");
        }
    }
}
