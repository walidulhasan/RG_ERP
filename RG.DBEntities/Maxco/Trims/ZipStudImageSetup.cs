using System;
using System.Collections.Generic;
using RG.DBEntities.Maxco.Setup;
using RG.DBEntities.Maxco.FabricAndYarn;

namespace RG.DBEntities.Maxco.Trims
{
    public partial class ZipStudImageSetup
    {
        public ZipStudImageSetup()
        {
            ZipStudSpecification = new HashSet<ZipStudSpecification>();
        }

        public short Id { get; set; }
        public byte MaterialId { get; set; }
        public string ImagePath { get; set; }
        public short VendorId { get; set; }
        public string CodeToDisplay { get; set; }
        public DateTime CreationDate { get; set; }
        public int? CollectionId { get; set; }
        public double? Price { get; set; }
        public long? TrimUnitId { get; set; }
        public long? TrimId { get; set; }
        public bool? IsMetalFinish { get; set; }
        public long? MetalFinishId { get; set; }
        public int? Consumption { get; set; }
        public int? SizeId { get; set; }
        public long? UserId { get; set; }
        public bool? IsValidate { get; set; }
        public int? DesignTypeId { get; set; }
        public string Code { get; set; }
        public double? Fob { get; set; }
        public double? Frieght { get; set; }
        public double? Duty { get; set; }
        public double? Clrtotal { get; set; }
        public string UserCode { get; set; }

        public virtual ZipStudMaterialSetup Material { get; set; }
        public virtual TrimUnit_Setup TrimUnit { get; set; }
        public virtual ICollection<ZipStudSpecification> ZipStudSpecification { get; set; }
    }
}
