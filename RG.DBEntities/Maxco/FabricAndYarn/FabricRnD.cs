using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.FabricAndYarn
{
    public partial class FabricRnD
    {
        public int Id { get; set; }
        public int? StyleId { get; set; }
        public int FabricRnDid { get; set; }
        public byte? JobNo { get; set; }
        public int? VersionNo { get; set; }
        public DateTime? CreationDate { get; set; }
        public string RnDno { get; set; }
        public string RndSuffix { get; set; }
        public bool? IsComplete { get; set; }
        public bool? IsEditable { get; set; }
        public long? AttributeInstanceId { get; set; }

        public virtual FabricRnDsheet FabricRnDNavigation { get; set; }
    }
}
