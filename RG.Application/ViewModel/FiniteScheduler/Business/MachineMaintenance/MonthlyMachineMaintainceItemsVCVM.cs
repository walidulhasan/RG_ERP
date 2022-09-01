using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.ViewModel.FiniteScheduler.Business.MachineMaintenance
{
    public class MonthlyMachineMaintainceItemsVCVM
    {
        public int MachineGroupID { get; set; }
        public string MachineGroup { get; set; }
        public string ReportHeader { get; set; }
        public MonthlyMachineMaintainceItemsVCVM()
        {
            MachineCheckItems = new List<MachineCheckItems>();
            GroupWiseMonthlyMachineMaintainceItems = new List<GroupWiseMonthlyMachineMaintainceItemsVM>();
        }
        public List<MachineCheckItems> MachineCheckItems { get; set; }
        public List<GroupWiseMonthlyMachineMaintainceItemsVM> GroupWiseMonthlyMachineMaintainceItems { get; set; }

    }
    public class GroupWiseMonthlyMachineMaintainceItemsVM
    {

        public GroupWiseMonthlyMachineMaintainceItemsVM()
        {
            
            MonthlyMachineMaintainceCheckDates = new List<MonthlyMachineMaintainceCheckDates>();
        }
        public int LocationID { get; set; }
        public string LocationName { get; set; }
        public int MachineID { get; set; }
        public string MachineName { get; set; }
       
        public List<MonthlyMachineMaintainceCheckDates> MonthlyMachineMaintainceCheckDates { get; set; }

    }
    public class MonthlyMachineMaintainceCheckDates
    {
        public MonthlyMachineMaintainceCheckDates()
        {

            CheckDateWiseItems = new List<CheckDateWiseItems>();
        }
        public DateTime? CheckDate { get; set; }
        public DateTime? ScheduleDate { get; set; }
        public int ? CheckDayDifference { get; set; }
        public string CheckDateMsg { get { return CheckDate.HasValue==true? CheckDate.Value.ToString("dd-MMM-yyyy"):""; } }
        public string ScheduleDateMsg { get { return ScheduleDate.HasValue==true? ScheduleDate.Value.ToString("dd-MMM-yyyy"):""; } }

        public List<CheckDateWiseItems> CheckDateWiseItems { get; set; }

    }
    public class MachineCheckItems
    {
        public string ItemName { get; set; }
        public string ItemNameShort { get; set; }
        public int SerialNo { get; set; }
    }
    public class CheckDateWiseItems
    {
        public string ItemName { get; set; }
        public string ItemNameShort { get; set; }
        public int MT_MachineAndMaintenanceCheckListMasterID { get; set; }
        public DateTime? ScheduleDate { get; set; }
        public DateTime? CheckedDate { get; set; }
        public string FirstAuthorityComments { get; set; }
        public string LastAuthorityComments { get; set; }
        public string LastAuthorityCommentsDate { get; set; }
        public int MT_MachineAndMaintenanceCheckListDetailsID { get; set; }
        public string MechanicalComments { get; set; }
        public string ElectricalComments { get; set; }
        public int SerialNo { get; set; }
        public bool MechanicalChecked { get; set; }
        public bool ElectricalChecked { get; set; }
        public string MechanicalTaskSupervisor { get; set; }
        public string ElectricalTaskSupervisor { get; set; }
        public string MechanicalWorkerComments { get; set; }
        public string ElectricalWorkerComments { get; set; }
        public string MechanicalTaskCompletedBy { get; set; }
        public string ElectricalTaskCompletedBy { get; set; }
    }
}
