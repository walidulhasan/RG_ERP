using FluentValidation;
using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Common.Mappings;
using RG.DBEntities.MaterialsManagement.Setup;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.ViewModel.MaterialsManagement.Setup
{
    public class YarnRackCreateVM:IMapFrom<YarnRackSetup>
    {
        public YarnRackCreateVM()
        {
            YarnSubRackSetup = new List<YarnSubRackVM>();
        }
        public int RackID { get; set; }
        [Display(Name = "Rack Name")]
        public string RackName { get; set; }
        [Display(Name = "Rack Short Name")]
        public string RackShortName { get; set; }
        [Display(Name = "Rack Serial")]
        public int RackSerial { get; set; }
        [Display(Name = "Building Floor ")]
        public int BuildingFloorID { get; set; }
        [Display(Name = "Building")]
        public int Building { get; set; }

        [Display(Name = "Description")]
        public string RackDescription { get; set; }
        [Display(Name = "Rack Row")]
        public int RackRow { get; set; }
        [Display(Name = "Rack Column")]
        public int RackColumn { get; set; }
        public List<SelectListItem> DDLRackNumber { get; set; }
        public List<SelectListItem> DDLBuilding { get; set; }
        public List<SelectListItem> DDLBuildingFloor { get; set; }
        public List<SelectListItem> DDLLBuildingFloor { get; set; }
       
        public int SubRackID { get; set; }
        public List<YarnSubRackVM> YarnSubRackSetup { get; set; }
        public void Mapping(MappingProfile profile)
        {
            profile.CreateMap<YarnRackCreateVM, YarnRackSetup>().ReverseMap();
        }
    }
    public class YarnSubRackVM : IMapFrom<YarnSubRackSetup>
    {
        public int SubRackID { get; set; }
        [Display(Name = "Rack Number")]
        public int RackID { get; set; }
        [Display(Name = "Sub. Rack Name")]
        public string SubRackName { get; set; }
        [Display(Name = "Sub.Rack Short Name")]
        public string SubRackShortName { get; set; }
        [Display(Name = "Sub. Rack Serial")]
        public int SubRackSerial { get; set; }
        public int SubRackRowSerial { get; set; }
        public int SubRackColumnSerial { get; set; }
        [Display(Name = "Sub.Rack Description")]
        public string SubRackDescription { get; set; }
        [Display(Name = "Storage Limit")]
        public decimal StorageLimit { get; set; }

        public void Mapping(MappingProfile profile)
        {
            profile.CreateMap<YarnSubRackVM, YarnSubRackSetup>();
        }
    }
    public class YarnRackValidator : AbstractValidator<YarnRackCreateVM>
    {
        public YarnRackValidator()
        {
            RuleFor(b => b.RackName).NotNull().WithMessage("Rack Name  is required.");
            RuleFor(b => b.RackShortName).NotNull().WithMessage("Rack Short Name  is required.");
            RuleFor(b => b.RackSerial).NotNull().WithMessage("Rack Serial  is required.");
            RuleFor(b => b.BuildingFloorID).NotNull().WithMessage("Building Floor  is required.");
            RuleFor(b => b.RackRow).NotNull().WithMessage("Rack Row  is required.");
            RuleFor(b => b.RackColumn).NotNull().WithMessage("Rack Column  is required.");
            RuleFor(b => b.Building).NotNull().WithMessage("Building  is required.");
        }
    }
}
