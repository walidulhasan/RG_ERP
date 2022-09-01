namespace RG.Application.Contracts.FiniteScheduler.Setups.MT_Machine_Setups.Queries.RequestResponseModel
{
    public class MachinesRM
    {
        public int MachineID { get; set; }
        public string MachineName { get; set; }
        public string MachineCode { get; set; }
        public int CompanyID { get; set; }
        public int LocationID { get; set; }
        public string LocationName { get; set; }
        public int MachineGroupID { get; set; }
        public string MachineGroup { get; set; }
        public int? MinMaintainceDurationDays { get; set; }
    }
}
