using RG.DBEntities.Maxco.FabricAndYarn;
using System;
using System.Collections.Generic;
using System.Text;

namespace RG.DBEntities.Maxco.Business
{
   public partial class ModelCosting
    {
        public ModelCosting()
        {
            ModelCostAllowances = new HashSet<ModelCostAllowances>();
          //  ModelEmbroCost = new HashSet<ModelEmbroCost>();
            ModelFinishFabricCost = new HashSet<ModelFinishFabricCost>();
            ModelGreigeFabricCosting = new HashSet<ModelGreigeFabricCosting>();
           // ModelOtherFabricCosting = new HashSet<ModelOtherFabricCosting>();
          //  ModelPackingAcc = new HashSet<ModelPackingAcc>();
            ModelPrintingCost = new HashSet<ModelPrintingCost>();
            ModelTrimCost = new HashSet<ModelTrimCost>();
            ModelWashingDetail = new HashSet<ModelWashingDetail>();
            ModelYarnCosting = new HashSet<ModelYarnCosting>();
            ModelSMVCosting = new HashSet<ModelSMVCosting>();
        }

        public int ID { get; set; }
        public long StyleID { get; set; }
        public int CollectionID { get; set; }
        public int? VersionNo { get; set; }
        public DateTime? CreationDate { get; set; }
        public int? UserID { get; set; }
        public string Comments { get; set; }
        public double? EuroRate { get; set; }
        public int? CurrencyID { get; set; }
        public long? VariationColorID { get; set; }
        public long? VariationSizeID { get; set; }
        public int? CSPCriteria { get; set; }

        public virtual ICollection<ModelCostAllowances> ModelCostAllowances { get; set; }
       // public virtual ICollection<ModelEmbroCost> ModelEmbroCost { get; set; }
        public virtual ICollection<ModelFinishFabricCost> ModelFinishFabricCost { get; set; }
        public virtual ICollection<ModelGreigeFabricCosting> ModelGreigeFabricCosting { get; set; }
       // public virtual ICollection<ModelOtherFabricCosting> ModelOtherFabricCosting { get; set; }
       // public virtual ICollection<ModelPackingAcc> ModelPackingAcc { get; set; }
        public virtual ICollection<ModelPrintingCost> ModelPrintingCost { get; set; }
        public virtual ICollection<ModelTrimCost> ModelTrimCost { get; set; }
        public virtual ICollection<ModelWashingDetail> ModelWashingDetail { get; set; }
        public virtual ICollection<ModelYarnCosting> ModelYarnCosting { get; set; }
        public virtual ICollection<ModelSMVCosting> ModelSMVCosting { get; set; }
        public virtual ModelApprovedCost ModelApprovedCost { get; set; }
    }
}
