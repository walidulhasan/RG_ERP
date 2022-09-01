using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.Application.ViewModel.AlgoHR.Business.Training
{
    public class TrainingIndexVM
    {
        public long ID { get; set; }
        [Display(Name = "Training Type")]
        public int TrainingTypeID { get; set; }
        [Display(Name ="Trainee Feedback")]
        public string Traineefeedback { get; set; }
        public List<SelectListItem> DDLTrainingType { get; set; }
        public List<SelectListItem> DDLTraineefeedback { get; set; }
    }
}
