using System;
using System.Collections.Generic;
using RG.DBEntities.Maxco.Setup;
using RG.DBEntities.Maxco.FabricAndYarn;

namespace RG.DBEntities.Maxco.Trims
{
    public partial class ZipPullerImageSetup
    {
        public ZipPullerImageSetup()
        {
            ZipPullerSpecification = new HashSet<ZipPullerSpecification>();
        }

        public int Id { get; set; }
        public byte MaterialId { get; set; }
        public string ImagePath { get; set; }
        public short VendorId { get; set; }
        public string CodeToDisplay { get; set; }
        public DateTime CreationDate { get; set; }
        public int? CollectionId { get; set; }
        public double? Price { get; set; }
        public long? TrimUnitId { get; set; }
        public long? TrimId { get; set; }
        public bool? IsFilled { get; set; }
        public double? Length { get; set; }
        public long? UserId { get; set; }
        public bool? IsValidate { get; set; }
        public int? DesignTypeId { get; set; }
        public string Code { get; set; }
        public double? Fob { get; set; }
        public double? Frieght { get; set; }
        public double? Duty { get; set; }
        public double? Clrtotal { get; set; }
        public byte? IsMetalFinish { get; set; }
        public long? MetalFinishId { get; set; }
        public string UserCode { get; set; }

        public virtual ZipPullerMaterialSetup Material { get; set; }
        public virtual TrimUnit_Setup TrimUnit { get; set; }
        public virtual ICollection<ZipPullerSpecification> ZipPullerSpecification { get; set; }
    }
}
