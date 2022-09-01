using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.FabricAndYarn
{
    public partial class FabricYarnSpecificationColorSetup
    {
        public int Id { get; set; }
        public long YarnSpecificationId { get; set; }
        public long? ColorsetId { get; set; }
        public string PantoneNo { get; set; }
        public int? VendorColorId { get; set; }
        public bool? IsSelected { get; set; }
        public byte? ColorIndex { get; set; }
    }
}
