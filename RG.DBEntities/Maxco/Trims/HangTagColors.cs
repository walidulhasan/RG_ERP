using System;
using System.Collections.Generic;
using RG.DBEntities.Maxco.FabricAndYarn;
using RG.DBEntities.Maxco.Setup;
namespace RG.DBEntities.Maxco.Trims
{
    public partial class HangTagColors
    {
        public int Id { get; set; }
        public long ColorSetId { get; set; }
        public string TrimColor { get; set; }
        public int HangTagSpecificationId { get; set; }
        public byte MatchId { get; set; }

        public virtual FabricSpecificationColor ColorSet { get; set; }
        public virtual HangTagSpecification HangTagSpecification { get; set; }
    }
}
