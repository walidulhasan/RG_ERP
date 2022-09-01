using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace RG.Application.ViewModel.MDSir.Salary
{
    public class SalaryAnalysisVM
    {
        public int SalaryAnalysisDivisionID { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public List<SelectListItem> DDLSalaryAnalysisDivision { get; set; }
        public List<SelectListItem> DDLMonth { get; set; }
        public List<SelectListItem> DDLYear { get; set; }
    }
}
