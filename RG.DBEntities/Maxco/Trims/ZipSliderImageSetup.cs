using System;
using System.Collections.Generic;
using RG.DBEntities.Maxco.Setup;
using RG.DBEntities.Maxco.FabricAndYarn;

namespace RG.DBEntities.Maxco.Trims
{
    public partial class ZipSliderImageSetup
    {
        public ZipSliderImageSetup()
        {
            ZipSpecification = new HashSet<ZipSpecification>();
        }

        public short Id { get; set; }
        public string ImagePath { get; set; }
        public short VendorId { get; set; }
        public string Code { get; set; }
        public DateTime CreationDate { get; set; }
        public int? CollectionId { get; set; }
        public double? Price { get; set; }
        public bool? IsPriceInsert { get; set; }
        public long? TrimUnitId { get; set; }
        public long? TrimId { get; set; }
        public int? SliderTypeId { get; set; }
        public bool? IsSliderMetalFinish { get; set; }
        public long? SliderMetalFinishId { get; set; }
        public byte? MaterialId { get; set; }
        public bool? IsTeethMetalFinish { get; set; }
        public int? TeethMetalFinishId { get; set; }
        public double? Number { get; set; }
        public int? OpenCloseId { get; set; }
        public bool? IsMale { get; set; }
        public int? TapeMaterialId { get; set; }
        public int? UserId { get; set; }
        public bool? IsValidate { get; set; }
        public int? DesignTypeId { get; set; }
        public string CodeToDisplay { get; set; }
        public double? Fob { get; set; }
        public double? Frieght { get; set; }
        public double? Duty { get; set; }
        public double? Clrtotal { get; set; }
        public string UserCode { get; set; }

        public virtual TrimUnit_Setup TrimUnit { get; set; }
        public virtual ICollection<ZipSpecification> ZipSpecification { get; set; }
    }
}
