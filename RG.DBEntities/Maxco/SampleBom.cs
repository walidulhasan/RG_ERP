using RG.DBEntities.Maxco.Business;
using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class SampleBom
    {
        public int Id { get; set; }
        public int SampleSuperBomid { get; set; }
        public long StyleId { get; set; }
        public int? ObjectId { get; set; }
        public int? FabricId { get; set; }

        public virtual SampleSuperBom SampleSuperBom { get; set; }
        public virtual Style Style { get; set; }
    }
}
