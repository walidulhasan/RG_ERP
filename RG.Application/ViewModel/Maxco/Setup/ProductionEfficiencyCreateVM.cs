using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.ViewModel.Maxco.Setup
{
    public class ProductionEfficiencyCreateVM
    {
        public int ID { get; set; }
        [Display(Name = "Date")]
        public string ProductionDate { get; set; }
        [Display(Name = "Standard Effi. % ")]
        [Range(typeof(decimal), "0", "100", ErrorMessage = "Less than 100 required")]
        public decimal? StandardEfficiencyPercent { get; set; }
        [Display(Name = "Overall Effi. %")]
        [Range(typeof(decimal), "0", "100", ErrorMessage = "Less than 100 required")]
        public decimal? OverAllEfficiencyPercent { get; set; }
    }
}
