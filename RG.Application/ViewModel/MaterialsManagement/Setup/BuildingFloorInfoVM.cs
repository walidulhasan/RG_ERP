using FluentValidation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.ViewModel.MaterialsManagement.Setup
{
    public class BuildingFloorInfoVM
    {
        [Display(Name = "Building Type")]
        public int BuildingType { get; set; }
        public int BuildingFloorID { get; set; }
        [Display(Name = "Building")]
        public int BuildingID { get; set; }
        [Display(Name = "Name")]
        public string FloorName { get; set; }
        [Display(Name = "Short Name")]
        public string FloorShortName { get; set; }
        [Display(Name = "Serial")]
        public int FloorSerial { get; set; }
        [Display(Name = "Description")]
        public string FloorDescription { get; set; }
        [Display(Name = "Floor Type")]
        public int FloorTypeID { get; set; }

        public List<SelectListItem> DDLBuildingType { get; set; }
        public List<SelectListItem> DDLBuilding { get; set; }
        public List<SelectListItem> DDLFloorType { get; set; }
        public List<SelectListItem> DDLSerial { get; set; }
    }
    public class BuildingFloorInfoVMValidator : AbstractValidator<BuildingFloorInfoVM>
    {
        public BuildingFloorInfoVMValidator()
        {
            RuleFor(b => b.BuildingType).NotEmpty().WithMessage("Building Type is required.");
            RuleFor(b => b.BuildingID).NotEmpty().WithMessage("Building is required.");
            RuleFor(b => b.FloorName).NotEmpty().WithMessage("Floor Name is required.");
            RuleFor(b => b.FloorShortName).NotEmpty().WithMessage("Short Name  is required.");
            RuleFor(b => b.FloorSerial).NotEmpty().WithMessage(" Serial Type  is required.");
            RuleFor(b => b.FloorDescription).NotEmpty().WithMessage("Description  is required.");
            RuleFor(b => b.FloorTypeID).NotEmpty().WithMessage("Type  is required.");
        }
    }
}
