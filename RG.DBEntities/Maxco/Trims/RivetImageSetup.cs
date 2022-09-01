using System;
using System.Collections.Generic;
using RG.DBEntities.Maxco.Setup;
using RG.DBEntities.Maxco.FabricAndYarn;

namespace RG.DBEntities.Maxco.Trims
{
    public partial class RivetImageSetup
    {
        public RivetImageSetup()
        {
            RivetSpecification = new HashSet<RivetSpecification>();
        }

        public int Id { get; set; }
        public string ImagePath { get; set; }
        public string CodeToDisplay { get; set; }
        public int VendorId { get; set; }
        public int TypeId { get; set; }
        public DateTime CreationDate { get; set; }
        public int? CollectionId { get; set; }
        public double? Price { get; set; }
        public bool? IsPriceInsert { get; set; }
        public long? TrimUnitId { get; set; }
        public long? TrimId { get; set; }
        public bool? IsMetalFinish { get; set; }
        public long? MetalFinishTypeId { get; set; }
        public int? SizeId { get; set; }
        public long? MeasurementScaleId { get; set; }
        public int? NoOfParts { get; set; }
        public long? UserId { get; set; }
        public bool? IsValidate { get; set; }
        public int? DesignTypeId { get; set; }
        public string Code { get; set; }
        public double? Fob { get; set; }
        public double? Frieght { get; set; }
        public double? Duty { get; set; }
        public double? Clrtotal { get; set; }
        public string UserCode { get; set; }

        public virtual TrimUnit_Setup TrimUnit { get; set; }
        public virtual RivetTypeSetup Type { get; set; }
        public virtual ICollection<RivetSpecification> RivetSpecification { get; set; }
    }
}
