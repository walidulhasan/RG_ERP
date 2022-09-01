using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.ViewModel.MaterialsManagement.Setup
{
    public class DailyProductionHourVM
    {
        public int ID { get; set; }
        [Display(Name = "Production Type")]
        [Required]
        public string ProductionType { get; set; }
        [Display(Name = "Time From")]
        [Required]
        public string TimeFrom { get; set; }
        [Display(Name = "Time To")]
        [Required]
        public string TimeTo { get; set; }
        [Display(Name = "Lap Timing")]
        [Required]
        public string LapTiming { get; set; }
        [Display(Name = "Description")]
        public string Description { get; set; }
    }
}
