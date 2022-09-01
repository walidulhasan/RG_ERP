using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Setup
{
    public partial class WashingSampleRecipeSetupDetail
    {
        public int RecipeProcessId { get; set; }
        public int RecipeMasterId { get; set; }
        public string ParentProcessSerialNo { get; set; }
        public int? ParentProcessId { get; set; }
        public bool? IsWetProcess { get; set; }
        public string ChildProcessSerialNo { get; set; }
        public int? ChildProcessId { get; set; }
        public string ChildProcessName { get; set; }
        public int? MachineRpm { get; set; }
        public int? LiquorRatio1 { get; set; }
        public int? LiquorRatio2 { get; set; }
        public double? Ph { get; set; }
        public int? ProcessTime { get; set; }
        public int? ProcessTimeUnitId { get; set; }
        public decimal? ProcessTemperatureFrom { get; set; }
        public decimal? ProcessTemperatureTo { get; set; }
        public int? ProcessTempUnitId { get; set; }
        public int? MaterialTypeId { get; set; }
        public int? MaterialCategoryId { get; set; }
        public int? ItemId { get; set; }
        public int? UnitId { get; set; }
        public int? PerUnitId { get; set; }
        public double? Value { get; set; }
        public decimal? Time { get; set; }
        public decimal? Temperature { get; set; }
        public int? HoldTime { get; set; }
        public bool Deleted { get; set; }
    }
}
