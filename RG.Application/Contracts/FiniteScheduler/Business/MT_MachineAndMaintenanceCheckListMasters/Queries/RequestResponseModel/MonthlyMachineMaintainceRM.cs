using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Contracts.FiniteScheduler.Business.MT_MachineAndMaintenanceCheckListMasters.Queries.RequestResponseModel
{
    public class MonthlyMachineMaintainceRM
    {
        public int MachineID { get; set; }
        public string MachineName { get; set; }
        public string MachineCode { get; set; }
        public string LocationName { get; set; }
        public DateTime? ScheduleDate { get; set; }
        public DateTime? CheckedDate { get; set; }
        public DateTime? NextCheckDate { get; set; }
        public int? StatusID { get; set; }
        public DateTime? StatusDate { get; set; }
        public string TaskCompletedBy { get; set; }
        public string FirstAuthorityComments { get; set; }
        public DateTime? FirstAuthorityCommentsDate { get; set; }
        public string LastAuthorityComments { get; set; }
        public DateTime? LastAuthorityCommentsDate { get; set; }
        public int DaysSerial { get; set; }
        public string DaysName { get; set; }
        public string ScheduleDayDifference { get; set; }
        public string NextDayDifference { get; set; }

        public string ScheduleDateST { get { return ScheduleDate.HasValue == true ? ScheduleDate.Value.ToString("dd-MMM-yyyy") : ""; } }
        public string CheckedDateST { get { return CheckedDate.HasValue == true ? CheckedDate.Value.ToString("dd-MMM-yyyy") : ""; } }
        public string NextCheckDateST { get { return NextCheckDate.HasValue == true ? NextCheckDate.Value.ToString("dd-MMM-yyyy") : ""; } }
    }
}
