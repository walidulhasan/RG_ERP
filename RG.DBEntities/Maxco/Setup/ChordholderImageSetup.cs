using RG.DBEntities.Maxco.Trims;
using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Setup
{
    public partial class ChordholderImageSetup
    {
        public ChordholderImageSetup()
        {
            ChordHolderSpecification = new HashSet<ChordHolderSpecification>();
        }

        public short Id { get; set; }
        public byte MaterialId { get; set; }
        public string ImagePath { get; set; }
        public string CodeToDisplay { get; set; }
        public string VendorId { get; set; }
        public DateTime CreationDate { get; set; }
        public int? CollectionId { get; set; }
        public double? Price { get; set; }
        public bool? IsPriceInsert { get; set; }
        public long? TrimUnitId { get; set; }
        public long? TrimId { get; set; }
        public bool? IsMetalFinish { get; set; }
        public long? MetalFinishTypeId { get; set; }
        public byte? DesignId { get; set; }
        public bool? IsSizeSkip { get; set; }
        public int? SizeId { get; set; }
        public long? MeasurementScaleId { get; set; }
        public int? UserId { get; set; }
        public bool? IsValidate { get; set; }
        public int? DesignTypeId { get; set; }
        public string Code { get; set; }
        public double? Fob { get; set; }
        public double? Frieght { get; set; }
        public double? Duty { get; set; }
        public double? Clrtotal { get; set; }
        public string UserCode { get; set; }

        public virtual ChordholderMaterialSetup Material { get; set; }
        public virtual TrimUnit_Setup TrimUnit { get; set; }
        public virtual ICollection<ChordHolderSpecification> ChordHolderSpecification { get; set; }
    }
}
