using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.ViewModel.AlgoHR.Business.PaySlip
{
    public class SalaryVM
    {
        public int EmployeeID { get; set; }
        public string EmployeeCode { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public List<SelectListItem> DDLMonth { get; set; }
        public List<SelectListItem> DDLYear { get; set; }

    }
}
