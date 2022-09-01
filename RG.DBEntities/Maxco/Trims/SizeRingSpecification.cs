using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Trims
{
    public partial class SizeRingSpecification
    {
        public SizeRingSpecification()
        {
            SizeRingColor = new HashSet<SizeRingColor>();
        }

        public int Id { get; set; }
        public long ObjectId { get; set; }
        public short ImageId { get; set; }
        public byte ProcurementSourceId { get; set; }
        public string Comments { get; set; }
        public byte VersionNo { get; set; }
        public byte Status { get; set; }
        public byte InsertionId { get; set; }
        public string TechComments { get; set; }
        public int? TrimStatus { get; set; }

        public virtual SizeRingImageSetup Image { get; set; }
        public virtual ICollection<SizeRingColor> SizeRingColor { get; set; }
    }
}
