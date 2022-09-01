using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace RG.Application.ViewModel.FiniteScheduler.Setup.MaintenanceSchedule
{
    public class GenerateFromExcelVM
    {
        public int MonthID { get; set; }
        public int YearID { get; set; }

        public string ScheduleData { get; set; }

        public List<SelectListItem> DDLMonths { get; set; }
        public List<SelectListItem> DDLYears { get; set; }
    }
}
