using RG.DBEntities.Maxco.Trims;
using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Setup
{
    public partial class SequenceImageSetup
    {
        public SequenceImageSetup()
        {
            SequenceSpecification = new HashSet<SequenceSpecification>();
        }

        public int Id { get; set; }
        public string ImagePath { get; set; }
        public string CodeToDisplay { get; set; }
        public int VendorId { get; set; }
        public int? CollectionId { get; set; }
        public double? Price { get; set; }
        public bool? IsPriceInsert { get; set; }
        public int? MaterialId { get; set; }
        public long? TrimUnitId { get; set; }
        public long? TrimId { get; set; }
        public int? FabricSequenceId { get; set; }
        public DateTime? CreationDate { get; set; }
        public long? UserId { get; set; }
        public bool? IsValidate { get; set; }
        public int? DesignTypeId { get; set; }
        public string Code { get; set; }
        public double? Fob { get; set; }
        public double? Frieght { get; set; }
        public double? Duty { get; set; }
        public double? Clrtotal { get; set; }
        public string UserCode { get; set; }

        public virtual SequenceMaterialSetup Material { get; set; }
        public virtual TrimUnit_Setup TrimUnit { get; set; }
        public virtual ICollection<SequenceSpecification> SequenceSpecification { get; set; }
    }
}
