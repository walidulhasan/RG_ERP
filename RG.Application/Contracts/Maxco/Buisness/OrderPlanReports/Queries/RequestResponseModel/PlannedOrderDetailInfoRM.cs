using System.Collections.Generic;

namespace RG.Application.Contracts.Maxco.Buisness.OrderPlanReports.Queries.RequestResponseModel
{
    public class PlannedOrderDetailInfoRM
    {
        public PlannedOrderDetailInfoRM()
        {
            FabricInfo = new List<GarmentAssortmentAndFabricsInfoRM>();
            GreigeFabric = new List<OrderGreigeFabricRM>();
            FinishFabric = new List<OrderFinishFabricRM>();
        }
        public List<GarmentAssortmentAndFabricsInfoRM> FabricInfo { get; set; }
        public List<OrderGreigeFabricRM> GreigeFabric { get; set; }
        public List<OrderFinishFabricRM> FinishFabric { get; set; }
    }
}
