using FluentValidation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.ViewModel.AlgoHR.Business.Training
{
    public class TrainingCalendarVM
    {
        public int MasterID { get; set; }
        public int DetailsID { get; set; }
        [Display(Name = "Year")]
        public int TrainingYear { get; set; }
        public string Title { get; set; }
        public string Venue { get; set; }
        [Display(Name = "Stakeholder")]
        public string Stakeholder { get; set; }

        public string Date { get; set; }
        public string Duration { get; set; }
        public string Trainer { get; set; }
        [Display(Name = "Type")]
        public string TrainingType { get; set; }
        [Display(Name = "Feedback")]
        public string Traineefeedback { get; set; }
        [Display(Name = "Category")]
        public int TrainingCategory { get; set; }

        public List<SelectListItem> YearList { get; set; }
        public List<SelectListItem> DDLDurations
        {
            get
            {
                return new List<SelectListItem>()
                {
                    new SelectListItem { Text = "30 min",Value="30 min" }
                    ,new SelectListItem { Text = "45 min",Value="45 min" }
                    ,new SelectListItem { Text = "1 hr",Value="1 hr" }
                    ,new SelectListItem { Text = "1 hr 30 min",Value="1 hr 30 min" }
                    ,new SelectListItem { Text = "2 hr",Value="2 min" }
                    ,new SelectListItem { Text = "2 hr 30 min",Value="2 hr 30 min" }
                    ,new SelectListItem { Text = "3 hr",Value="3 hr" }
                    ,new SelectListItem { Text = "3 hr 30 min",Value="3 hr 30 min" }
                    ,new SelectListItem { Text = "4 hr",Value="4 hr" }
                    ,new SelectListItem { Text = "4 hr 30 min",Value="4 hr 30 min" }
                    ,new SelectListItem { Text = "5 hr",Value="5 hr" }
                    ,new SelectListItem { Text = "5 hr 30 min",Value="5 hr 30 min" }
                    ,new SelectListItem { Text = "6 hr",Value="6 hr" }
                };
            }
        }
        public List<SelectListItem> DDLTrainingCategory { get; set; }
        public List<SelectListItem> DDLTrainingTypes { get; set; }
        public List<SelectListItem> DDLTraineefeedback { get; set; }
    }

    public class TrainingCalendarVMValidator : AbstractValidator<TrainingCalendarVM>
    {
        public TrainingCalendarVMValidator()
        {
            RuleFor(b => b.Title).NotEmpty().WithMessage("Title is required.");
            RuleFor(b => b.Venue).NotEmpty().WithMessage("Venue is required.");
            RuleFor(b => b.Trainer).NotEmpty().WithMessage("Trainer is required.");
            RuleFor(b => b.Duration).NotEmpty().WithMessage("Duration  is required.");
            RuleFor(b => b.TrainingType).NotEmpty().WithMessage("Training Type  is required.");
            RuleFor(b => b.TrainingCategory).NotEmpty().WithMessage("Training Category  is required.");
            RuleFor(b => b.Stakeholder).NotEmpty().WithMessage("stakeholder  is required.");
        }
    }
}

