using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace RG.DBEntities.Maxco.Business
{
    public class Plan_StyleFabrics : DefaultTableProperties
    {
        public Plan_StyleFabrics()
        {
            Plan_FinishFabric = new List<Plan_FinishFabric>();
            Plan_Knitting = new List<Plan_Knitting>();
            Plan_Shipment = new List<Plan_Shipment>();
            Plan_Sewing = new List<Plan_Sewing>();
            Plan_Cutting = new List<Plan_Cutting>();
            Plan_DyeingProduction = new List<Plan_DyeingProduction>();
            Plan_FabricDeliveryCommitment = new List<Plan_FabricDeliveryCommitment>();
            Plan_FabricArtWork = new List<Plan_FabricArtWork>();
            Plan_FabricBatchCommitment = new List<Plan_FabricBatchCommitment>();

        }
        public int StyleFabricsID { get; set; }
        [ForeignKey("Plan_Versions")]
        public int PlanVersionID { get; set; }
        public int StyleID { get; set; }
        public int FabricTypeID { get; set; }
        public int FabricQualityID { get; set; }
        public int GSM { get; set; }
        public string FabricComposition { get; set; }
        public string PantoneNo { get; set; }
        public decimal RequiredQuantity { get; set; }
        public decimal MainFabricUseConsumption { get; set; }
        public int GroupID { get; set; }
        public decimal RibQuantity { get; set; }
        public decimal RibUseConsumption { get; set; }
        public int StyleOrderQuantity { get; set; }
        public int FabricSL { get; set; }
        public List<Plan_FinishFabric> Plan_FinishFabric { get; set; }
        public List<Plan_Knitting> Plan_Knitting { get; set; }
        public List<Plan_Shipment> Plan_Shipment { get; set; }
        public List<Plan_Sewing> Plan_Sewing { get; set; }
        public List<Plan_Cutting> Plan_Cutting { get; set; }
        public List<Plan_DyeingProduction> Plan_DyeingProduction { get; set; }
        public List<Plan_FabricDeliveryCommitment> Plan_FabricDeliveryCommitment { get; set; }
        public List<Plan_FabricArtWork> Plan_FabricArtWork { get; set; }
        public List<Plan_FabricBatchCommitment> Plan_FabricBatchCommitment { get; set; }
        public virtual Plan_Versions Plan_Versions { get; set; }

        


    }
}
