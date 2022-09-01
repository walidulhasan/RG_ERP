using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.FabricAndYarn
{
    public partial class FabricRnDsheet
    {
        public FabricRnDsheet()
        {
            FabricRnD = new HashSet<FabricRnD>();
        }

        public string StemMoisture { get; set; }
        public string SpeedMpm { get; set; }
        public string ConveyorRatio { get; set; }
        public string PlatterRatio { get; set; }
        public int Id { get; set; }
        public int? Gsmgreige { get; set; }
        public int? MachineGauge { get; set; }
        public int? MachineSize { get; set; }
        public double? NumberOfNeedles { get; set; }
        public int? FlowMeter1 { get; set; }
        public int? FlowMeter2 { get; set; }
        public int? FlowMeter3 { get; set; }
        public int? FlowMeter4 { get; set; }
        public string StitchLength1 { get; set; }
        public string StitchLength2 { get; set; }
        public string StitchLength3 { get; set; }
        public string StitchLength4 { get; set; }
        public int? CoursesPerInch { get; set; }
        public int? WalesPerInch { get; set; }
        public double? GreigeWidth { get; set; }
        public string LotNumber { get; set; }
        public string DyeingProcessId { get; set; }
        public int? GsmafterDrying { get; set; }
        public float? WidthafterDrying { get; set; }
        public float? GsmafterRaising { get; set; }
        public double? WidthafterRaising { get; set; }
        public string ThirdWashShrinkageAfterDrying1 { get; set; }
        public string ThirdWashShrinkageAfterDrying2 { get; set; }
        public float? ThirdWashTorqueAfterDrying1 { get; set; }
        public int? GsmafterShrinkage { get; set; }
        public double? WidthAtCompaction { get; set; }
        public int? CompactionParameter1 { get; set; }
        public int? CompactionParameter2 { get; set; }
        public int? CompactionParameter3 { get; set; }
        public int? CompactionPercentage { get; set; }
        public int? GsmatCompaction { get; set; }
        public double? RelaxedWidth { get; set; }
        public float? RelaxedGsm { get; set; }
        public string WidthAfterPanelWash { get; set; }
        public string GsmafterPanelWash { get; set; }
        public string ShrinkageOnPanelOnePer1 { get; set; }
        public string ShrinkageOnPanelOnePer2 { get; set; }
        public string ShrinkageOnPanelTwoPer1 { get; set; }
        public string ShrinkageOnPanelTwoPer2 { get; set; }
        public string ShrinkageOnPanelThreePer1 { get; set; }
        public string ShrinkageOnPanelThreePer2 { get; set; }
        public string ShrinkageOnPanelTestMethod { get; set; }
        public string ShrinkageThirdWashDryer { get; set; }
        public string TorqueOnPanelOnePer1 { get; set; }
        public string TorqueOnPanelOnePer2 { get; set; }
        public string TorqueOnPanelTwoPer1 { get; set; }
        public string TorqueOnPanelTwoPer2 { get; set; }
        public string TorqueOnPanelThreePer1 { get; set; }
        public string TorqueOnPanelThreePer2 { get; set; }
        public string TorqueOnPanelTestMethod { get; set; }
        public string TorqueThirdWashTumbleDryer { get; set; }
        public string ShrinkageOnGarmentOnePer1 { get; set; }
        public string ShrinkageOnGarmentOnePer2 { get; set; }
        public string ShrinkageOnGarmentTwoPer1 { get; set; }
        public string ShrinkageOnGarmentTwoPer2 { get; set; }
        public string ShrinkageOnGarmentThreePer1 { get; set; }
        public string ShrinkageOnGarmentThreePer2 { get; set; }
        public string ShrinkageOnGarmentTestMethod { get; set; }
        public string ShrinkageGarmentThirdWashDryer { get; set; }
        public string TorqueOnGarmentOnePer1 { get; set; }
        public string TorqueOnGarmentOnePer2 { get; set; }
        public string TorqueOnGarmentTwoPer1 { get; set; }
        public string TorqueOnGarmentTwoPer2 { get; set; }
        public string TorqueOnGarmentThreePer1 { get; set; }
        public string TorqueOnGarmentThreePer2 { get; set; }
        public string TorqueGarmentTestMethod { get; set; }
        public string TorqueGarmentThirdWashDryer { get; set; }
        public string Comments { get; set; }
        public long? JobNo { get; set; }
        public long? StyleId { get; set; }

        public virtual ICollection<FabricRnD> FabricRnD { get; set; }
    }
}
