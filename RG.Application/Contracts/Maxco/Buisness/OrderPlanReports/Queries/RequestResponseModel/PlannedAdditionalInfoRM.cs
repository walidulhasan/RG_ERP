using System.Collections.Generic;

namespace RG.Application.Contracts.Maxco.Buisness.OrderPlanReports.Queries.RequestResponseModel
{
    public class PlannedAdditionalInfoRM
    {
        public List<BatchCommitmentRM> PlanKnitting { get; set; }
        public List<BatchCommitmentRM> BatchCommitment { get; set; }
        public List<BatchCommitmentRM> DeliveryCommitment { get; set; }
        public List<ArtWorkRM> ArtWork { get; set; }
        public List<DyeingProductionLocationRM> DyeingProductionLocation { get; set; }
    }
}
