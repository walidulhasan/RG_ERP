using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class WashingRecipeOptionsToProcessAssociationDetail
    {
        public int Id { get; set; }
        public int MasterId { get; set; }
        public bool IsWetProcess { get; set; }
        public int? FabricCategoryId { get; set; }
        public int ProcessCodeId { get; set; }
        public bool MachineRpm { get; set; }
        public bool LiquorRatio { get; set; }
        public bool Ph { get; set; }
        public bool Time { get; set; }
        public bool Temperature { get; set; }
        public bool Deleted { get; set; }
        public double? Rpm { get; set; }
        public double? Lr { get; set; }
        public double? Phvalue { get; set; }
        public double? TimeValue { get; set; }
        public int? TimeUnit { get; set; }
        public double? TemperatureValue { get; set; }
        public int? TemperatureUnit { get; set; }
        public double? TemperatureValue2 { get; set; }
        public bool? IsLiquorRatioExceptional { get; set; }
        public double? MaxExecutionValue { get; set; }
        public short? ExecutionUnitId { get; set; }
    }
}
