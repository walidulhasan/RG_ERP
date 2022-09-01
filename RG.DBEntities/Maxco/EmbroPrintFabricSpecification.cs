using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class EmbroPrintFabricSpecification
    {
        public EmbroPrintFabricSpecification()
        {
            EmbroAppliqueThreads = new HashSet<EmbroAppliqueThreads>();
        }

        public long Id { get; set; }
        public long? Id1 { get; set; }
        public long? Id2 { get; set; }
        public int ObjectId { get; set; }
        public int? OrderStyleElementId { get; set; }
        public int? FabricQualityId { get; set; }
        public string PantoneNo { get; set; }
        public int? Gsm { get; set; }
        public int? CompositionId { get; set; }
        public int? PalletId { get; set; }
        public int? FabricTypeId { get; set; }
        public string FabricComposition { get; set; }
        public double? FinishedWidth { get; set; }
        public int? DyeingId { get; set; }
        public int? DenimWeightId { get; set; }
        public string BodyPart { get; set; }
        public int? FabricSpecificationId { get; set; }

        public virtual ICollection<EmbroAppliqueThreads> EmbroAppliqueThreads { get; set; }
    }
}
