using RG.DBEntities.Maxco.Setup;
using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class EmbroLayers
    {
        public EmbroLayers()
        {
            EmbroAppliqueThreads = new HashSet<EmbroAppliqueThreads>();
        }

        public long Id { get; set; }
        public int PalletTypeId { get; set; }
        public string PantoneNo { get; set; }
        public int? NoOfStitches { get; set; }
        public double? ThreadConsumption { get; set; }
        public byte TypeId { get; set; }
        public int MaterialId { get; set; }
        public int BrandId { get; set; }
        public int CatNo { get; set; }
        public bool IsRewind { get; set; }
        public int ObjectId { get; set; }
        public int? ImageId { get; set; }
        public int? SeqNo { get; set; }

        public virtual EmbroBrandSetup Brand { get; set; }
        public virtual EmbroMaterialSetup Material { get; set; }
        public virtual EmbroSpecification Object { get; set; }
        public virtual EmbroTypeSetup Type { get; set; }
        public virtual ICollection<EmbroAppliqueThreads> EmbroAppliqueThreads { get; set; }
    }
}
