using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Contracts.Maxco.Buisness.OrderPlanReports.Queries.RequestResponseModel
{
    public class PlanArtWorkFabricConsumptionRM
    {
        public int FabricMonthSl { get; set; }
        public string FabricMonth { get; set; }
        public int BuyerID { get; set; }
        public string Buyer { get; set; }
        public int OrderID { get; set; }
        public string OrderNo { get; set; }
        public int StyleID { get; set; }
        public string ArtwarkName { get; set; }
        public DateTime ShipmentDate { get; set; }
        public decimal ArtQuantity { get; set; }
        public string Pantone { get; set; }
        public decimal MainFabricConsumption { get; set; }
        public decimal RibConsumption { get; set; }
        public decimal TotalFabricConsumption { get; set; }
        public decimal WastagePercent { get; set; }

        public decimal OrderArtWorkQuantity { get; set; }
        public decimal OrderTotalArtWorkFinishKg { get; set; }
        public decimal OrderMainArtWorkFinishKg { get; set; }
        public decimal OrderRibArtWorkFinishKg { get; set; }
        //public decimal OrderArtWorkFinishWithWastageKg { get; set; }
    }
}
