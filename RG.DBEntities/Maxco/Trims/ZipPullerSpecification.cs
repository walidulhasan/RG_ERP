using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Trims
{
    public partial class ZipPullerSpecification
    {
        public ZipPullerSpecification()
        {
            ZipPullerPlacementInstruction = new HashSet<ZipPullerPlacementInstruction>();
            ZipStudSpecification = new HashSet<ZipStudSpecification>();
        }

        public long Id { get; set; }
        public int ObjectId { get; set; }
        public int ImageId { get; set; }
        public double Length { get; set; }
        public double? Consumption { get; set; }
        public byte ProcurementSourceId { get; set; }
        public string Comments { get; set; }
        public byte VersionNo { get; set; }
        public bool? IsFilled { get; set; }
        public string TechComments { get; set; }
        public int? DesignTypeId { get; set; }
        public byte? IsMetalFinish { get; set; }
        public byte? IsFabricColor { get; set; }
        public int? TrimStatus { get; set; }

        public virtual ZipPullerImageSetup Image { get; set; }
        public virtual ZipSpecification Object { get; set; }
        public virtual ICollection<ZipPullerPlacementInstruction> ZipPullerPlacementInstruction { get; set; }
        public virtual ICollection<ZipStudSpecification> ZipStudSpecification { get; set; }
    }
}
