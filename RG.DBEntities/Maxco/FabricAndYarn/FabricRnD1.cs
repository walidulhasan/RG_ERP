using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.FabricAndYarn
{
    public partial class FabricRnD1
    {
        public short GreigeGsm { get; set; }
        public int MachineSize { get; set; }
        public string NoOfNeedles { get; set; }
        public int AfterDryingGsm { get; set; }
        public double Width { get; set; }
        public double? ThirdWashShrinkageLw { get; set; }
        public double? ThirdWashShrinkageWw { get; set; }
        public int AfterShrinkageGsm { get; set; }
        public double CalenderWidth { get; set; }
        public string CompactionParameter { get; set; }
        public double RelaxedWidth { get; set; }
        public int FinishedGsm { get; set; }
        public double? RwidthAfterPanelWashing { get; set; }
        public int? RgsmafterPanelWashing { get; set; }
        public int? FgsmafterDyeingWashing { get; set; }
        public string Comments { get; set; }
        public int Id { get; set; }
        public int? RelaxedGsm { get; set; }
        public double? RaisingWidth { get; set; }
        public int? RaisingGsm { get; set; }
        public double? Torque { get; set; }
        public double? WidthAfterShrinkage { get; set; }
        public double? CompactionPer { get; set; }
        public int? WalesPerInch { get; set; }
        public int? MachineGauge { get; set; }
        public int? GreigeWidth { get; set; }
        public double? FlowMeterA { get; set; }
        public double? FlowMeterB { get; set; }
        public double? FlowMeterC { get; set; }
        public double? FlowMeterD { get; set; }
        public string LotNumber { get; set; }
        public int? CoursesPerInch { get; set; }
        public string StitchLengthA { get; set; }
        public int? StitchLengthB { get; set; }
        public int? StitchLengthC { get; set; }
        public int? StitchLengthD { get; set; }
        public int? DyeingProcessId { get; set; }
    }
}
