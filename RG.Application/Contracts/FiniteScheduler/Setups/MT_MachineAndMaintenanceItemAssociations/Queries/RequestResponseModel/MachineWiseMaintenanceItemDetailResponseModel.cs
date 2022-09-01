namespace RG.Application.Contracts.FiniteScheduler.Setups.MT_MachineAndMaintenanceItemAssociations.Queries.RequestResponseModel
{
    public class MachineWiseMaintenanceItemDetailResponseModel
    {
        public int MasterID { get; set; }
        public int AssociationID { get; set; }
        public int MachineID { get; set; }
        public int MaintenanceItemID { get; set; }
        public string ItemName { get; set; }
        public bool MechanicalChecked { get; set; }
        public string MechanicalComments { get; set; }
        public bool ElectricalChecked { get; set; }
        public string ElectricalComments { get; set; }
        public int ItemCategoryID { get; set; }
        public int MasterDetailID { get; set; }


    }
}
