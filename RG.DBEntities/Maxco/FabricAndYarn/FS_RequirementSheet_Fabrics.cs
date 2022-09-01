using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RG.DBEntities.Maxco.FabricAndYarn
{
    public class FS_RequirementSheet_Fabrics
    {
        public FS_RequirementSheet_Fabrics()
        {
             FS_Fabric_Details = new HashSet<FS_Fabric_Details>();
             FS_Fabric_YarnDetail = new HashSet<FS_Fabric_YarnDetail>();
        }

        public int ID { get; set; }
        [ForeignKey("FS_RequirementSheet_Master")]
        public int RequirementSheetID { get; set; }
        public long AttributeInstanceID { get; set; }
        public double RequiredQuantity { get; set; }
        public int? TypeID { get; set; }
        public int? GroupID { get; set; }
        public string PantoneNo { get; set; }
        public int WastagePercent { get; set; }
        public double? BalanceQuantity { get; set; }
        public double? ExtraCut { get; set; }
        public double? CuttingWastage { get; set; }
        public double? DyeingWastage { get; set; }
        public double? KnittingWastage { get; set; }
        public double? WashingWastage { get; set; }
        public double? FinishingWastage { get; set; }
        public double? PrintingWastage { get; set; }
        public double? ConPerPiece { get; set; }
        public decimal? Gaqty { get; set; }
        public double? WastagePer { get; set; }
        public int? ProcurementUnitID { get; set; }
        public int? FinishFabricCodeID { get; set; }

        public virtual ICollection<FS_Fabric_Details> FS_Fabric_Details { get; set; }
        public virtual ICollection<FS_Fabric_YarnDetail> FS_Fabric_YarnDetail { get; set; }
        public virtual FS_RequirementSheet_Master FS_RequirementSheet_Master { get; set; }
    }
}
