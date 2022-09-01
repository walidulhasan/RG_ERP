using System;
using System.Collections.Generic;
using RG.DBEntities.Maxco.Setup;
using RG.DBEntities.Maxco.FabricAndYarn;

namespace RG.DBEntities.Maxco.Trims
{
    public partial class SizeRingImageSetup
    {
        public SizeRingImageSetup()
        {
            SizeRingSpecification = new HashSet<SizeRingSpecification>();
        }

        public short Id { get; set; }
        public string ImagePath { get; set; }
        public short VendorId { get; set; }
        public string Code { get; set; }
        public byte DesignId { get; set; }
        public DateTime CreationDate { get; set; }
        public int CollectionId { get; set; }
        public double? Price { get; set; }
        public bool? IsPriceInsert { get; set; }
        public long? TrimUnitId { get; set; }
        public long? TrimId { get; set; }
        public long? UserId { get; set; }
        public bool? IsValidate { get; set; }
        public int? DesignTypeId { get; set; }
        public double? Fob { get; set; }
        public double? Frieght { get; set; }
        public double? Duty { get; set; }
        public double? Clrtotal { get; set; }
        public string UserCode { get; set; }

        public virtual SizeRingDesignSetup Design { get; set; }
        public virtual TrimUnit_Setup TrimUnit { get; set; }
        public virtual ICollection<SizeRingSpecification> SizeRingSpecification { get; set; }
    }
}
