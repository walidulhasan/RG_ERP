using System;
using System.Collections.Generic;
using RG.DBEntities.Maxco.Setup;

using RG.DBEntities.Maxco.FabricAndYarn;

namespace RG.DBEntities.Maxco.Trims
{
    public partial class FurImageSetup
    {
        public FurImageSetup()
        {
            FurSpecification = new HashSet<FurSpecification>();
        }

        public int Id { get; set; }
        public string ImagePath { get; set; }
        public byte MaterialId { get; set; }
        public string CodeToDisplay { get; set; }
        public short VendorId { get; set; }
        public DateTime CreationDate { get; set; }
        public int? CollectionId { get; set; }
        public double? Price { get; set; }
        public bool? IsPriceInsert { get; set; }
        public long? TrimUnitId { get; set; }
        public long? TrimId { get; set; }
        public int? WeaveId { get; set; }
        public int? WidthId { get; set; }
        public int? TrimMeasurementScaleId { get; set; }
        public int? DyedId { get; set; }
        public long? UserId { get; set; }
        public int? DesignTypeId { get; set; }
        public string Code { get; set; }
        public double? Fob { get; set; }
        public double? Frieght { get; set; }
        public double? Duty { get; set; }
        public double? Clrtotal { get; set; }
        public string UserCode { get; set; }

        public virtual FurMaterialSetup Material { get; set; }
        public virtual TrimUnit_Setup TrimUnit { get; set; }
        public virtual ICollection<FurSpecification> FurSpecification { get; set; }
    }
}
