using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Trims
{
    public partial class ZipStudSpecification
    {
        public ZipStudSpecification()
        {
            ZipStudColor = new HashSet<ZipStudColor>();
        }

        public int Id { get; set; }
        public long ObjectId { get; set; }
        public byte MaterialId { get; set; }
        public short ImageId { get; set; }
        public bool IsMetalFinish { get; set; }
        public byte VersionNo { get; set; }
        public string Comments { get; set; }
        public bool? IsFabricColor { get; set; }
        public int SizeId { get; set; }
        public byte ProcurementSourceId { get; set; }
        public int? Consumption { get; set; }
        public string TechComments { get; set; }
        public int? DesignTypeId { get; set; }
        public int? TrimStatus { get; set; }

        public virtual ZipStudImageSetup Image { get; set; }
        public virtual ZipPullerSpecification Object { get; set; }
        public virtual ZipStudSizeSetup Size { get; set; }
        public virtual ICollection<ZipStudColor> ZipStudColor { get; set; }
    }
}
