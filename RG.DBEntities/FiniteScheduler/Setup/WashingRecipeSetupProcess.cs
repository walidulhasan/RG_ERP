using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Setup
{
    public partial class WashingRecipeSetupProcess
    {
        public long Id { get; set; }
        public int? RecipeId { get; set; }
        public int? ParentProcessId { get; set; }
        public int? SequenceNo { get; set; }
        public int? ProcessId { get; set; }
        public string ProcessName { get; set; }
        public byte? IsWetProcess { get; set; }
        public byte? HasLiquorRatio { get; set; }
        public double? LiquorRatio1 { get; set; }
        public double? LiquorRatio2 { get; set; }
        public byte? HasPh { get; set; }
        public double? Ph { get; set; }
        public byte? HasMachineRpm { get; set; }
        public double? MachineRpm { get; set; }
        public string MachineType { get; set; }
        public byte? HasTime { get; set; }
        public double? MaxProcessTime { get; set; }
        public int? TimeUnitId { get; set; }
        public string TimeUnit { get; set; }
        public byte? HasTemperature { get; set; }
        public double? TemperatureFrom { get; set; }
        public double? TemperatureTo { get; set; }
        public int? TemperatureUnitId { get; set; }
        public string TemperatureUnit { get; set; }
    }
}
