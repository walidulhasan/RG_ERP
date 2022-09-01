using RG.DBEntities.Maxco.Business;

namespace RG.Application.Contracts.Maxco.Buisness.Plan_OrderMasters.Commands.DataTransferModel
{
    public class Plan_VersionsDTM
    {
        public int PlanVersionID { get; set; }
        public int VersionNo { get; set; }
        public int PlanID { get; set; }
        public Plan_Versions Plan_Versions { get; set; }
    }
}
