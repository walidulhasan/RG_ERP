using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.ViewModel.AlgoHR.Business.CompanyMonthlySalary
{
    public class CompanyMonthlySalaryVM
    {
        [Display(Name ="Company")]
        public int CompanyID { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }

        public List<SelectListItem> DDLMonth { get; set; }
        public List<SelectListItem> DDLYear { get; set; }
        public List<SelectListItem> DDLCompany { get; set; }
    }
}
