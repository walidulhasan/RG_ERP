using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class FsRequirementSheetFabricsOld07may2019
    {
        public int Id { get; set; }
        public int RequirementSheetId { get; set; }
        public long AttributeInstanceId { get; set; }
        public double RequiredQuantity { get; set; }
        public int? TypeId { get; set; }
        public int? GroupId { get; set; }
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
        public int? ProcurementUnitId { get; set; }
        public int? FinishFabricCodeId { get; set; }
    }
}
