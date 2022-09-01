namespace RG.Application.Contracts.FiniteScheduler.Business.MT_MachineAndMaintenanceCheckListMasters.Queries.RequestResponseModel
{
    public class MachineAndMaintenanceCheckRM
    {
        public int ID { get; set; }
        public string LocationName { get; set; }
        public string MachineName { get; set; }
        public string ScheduleDate { get; set; }
        public string CheckedDate { get; set; }
        public string StatusName { get; set; }
        public string ElectricalTaskCompletedBy { get; set; }
        public string ElectricalTaskCompletedByName { get; set; }
        public string ElectricalTaskSupervisor { get; set; }
        public string ElectricalTaskSupervisorName { get; set; }
        public string MechanicalTaskCompletedBy { get; set; }
        public string MechanicalTaskCompletedByName { get; set; }
        public string MechanicalTaskSupervisor { get; set; }
        public string MechanicalTaskSupervisorName { get; set; }
        public string FirstAuthorityComments { get; set; }
        public string LastAuthorityComments { get; set; }
        public int DayDifference { get; set; }
    }
}
