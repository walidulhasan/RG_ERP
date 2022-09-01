using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Trims
{
    public partial class FurSpecification
    {
        public FurSpecification()
        {
            FurColor = new HashSet<FurColor>();
            FurPlacementInstruction = new HashSet<FurPlacementInstruction>();
            FurStripes = new HashSet<FurStripes>();
            FurYarnSpecification = new HashSet<FurYarnSpecification>();
        }

        public long Id { get; set; }
        public int ImageId { get; set; }
        public byte WeaveId { get; set; }
        public byte WidthId { get; set; }
        public double? Shrinkage { get; set; }
        public byte DyedId { get; set; }
        public byte ProcurementSourceId { get; set; }
        public byte VersionNo { get; set; }
        public string Comments { get; set; }
        public long SelectedTrimId { get; set; }
        public byte Status { get; set; }
        public byte? Consumption { get; set; }
        public short? TrimMeasurementScaleId { get; set; }
        public byte? WidthMeasurementScaleId { get; set; }
        public byte InsertionId { get; set; }
        public string TechComments { get; set; }
        public int? DesignTypeId { get; set; }
        public int? TrimStatus { get; set; }

        public virtual FurDyeingSetup Dyed { get; set; }
        public virtual FurImageSetup Image { get; set; }
        public virtual FurWeaveSetup Weave { get; set; }
        public virtual FurWidthSetup Width { get; set; }
        public virtual ICollection<FurColor> FurColor { get; set; }
        public virtual ICollection<FurPlacementInstruction> FurPlacementInstruction { get; set; }
        public virtual ICollection<FurStripes> FurStripes { get; set; }
        public virtual ICollection<FurYarnSpecification> FurYarnSpecification { get; set; }
    }
}
