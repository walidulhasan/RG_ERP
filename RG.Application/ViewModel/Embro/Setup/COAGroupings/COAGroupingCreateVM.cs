using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Common.Mappings;
using RG.DBEntities.Embro.Setup;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.ViewModel.Embro.Setup.COAGroupings
{
    public class COAGroupingCreateVM : IMapFrom<COAGroup>
    {
        public int GroupID { get; set; }
        [Display(Name = "Group Category")]

        public int GroupCategoryID { get; set; }
        [Display(Name = "Group Name")]
        public string GroupName { get; set; }
        [Display(Name = "Group Code")]

        public string GroupCode { get; set; }
        [Display(Name = "Group Serial")]

        public int GroupSerial { get; set; }

        public List<SelectListItem> DDLGroupSerial { get; set; }
        public List<SelectListItem> DDLCOAGroupingCategory { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<COAGroupingCreateVM, COAGroup>();
        }

    }
    public class COAGroupingCreateVMValidator : AbstractValidator<COAGroupingCreateVM>
    {
        public COAGroupingCreateVMValidator()
        {
            RuleFor(b => b.GroupCategoryID).NotNull().WithMessage("Group Category  is required.");

            RuleFor(b => b.GroupName).NotNull().WithMessage("Group Name is required.");

            RuleFor(b => b.GroupCode).NotNull().WithMessage("Group Code is required.");

            RuleFor(b => b.GroupSerial).NotNull().WithMessage("Group Serial is required.");
        }
    }
}
