using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.ViewModel.AlgoHR.Business.Training
{
    public class TrainingScheduleVM
    {
        [Display(Name ="Training Category")]
        public int TrainingCategoryID { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public List<SelectListItem> DDLMonth { get; set; }
        public List<SelectListItem> DDLYear { get; set; }
        public List<SelectListItem> DDLTrainingCategory { get; set; }
    }
}
