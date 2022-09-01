using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.FabricAndYarn
{
    public partial class FabricImage_Setup
    {
        public FabricImage_Setup()
        {
            FabricSpecification = new HashSet<FabricSpecification>();
        }

        public int ID { get; set; }
        public int? VendorId { get; set; }
        public string ImagePath { get; set; }
        public short Code { get; set; }
        public bool? IsFeeder { get; set; }
        public byte? NoOfStripes { get; set; }

        public virtual ICollection<FabricSpecification> FabricSpecification { get; set; }
    }
}
