using RG.DBEntities.Maxco.FabricAndYarn;
using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Setup
{
    public partial class GreigeFabricCode_Setup
    {
        public GreigeFabricCode_Setup()
        {
            GreigeFabricTippingVeltSpecification = new HashSet<GreigeFabricTippingVeltSpecification>();
            GreigeFabricYarnSpecification = new HashSet<GreigeFabricYarnSpecification>();
        }

        public int Id { get; set; }
        public string Code { get; set; }
        public int? FabricCategoryId { get; set; }
        public int? FabricQualityId { get; set; }
        public int? Gsm { get; set; }
        public byte? FabricGuageId { get; set; }
        public byte? FabricMachineTypeId { get; set; }
        public byte? FabricDyeingTypeId { get; set; }
        public double? FinishedLength { get; set; }
        public double? FinishedWidth { get; set; }
        public string FabricComposition { get; set; }
        public byte? DessignTypeId { get; set; }

        public virtual FabricYarnDesignType_Setup DessignType { get; set; }
        public virtual FabricCategory_setup FabricCategory { get; set; }
        public virtual FabricDyeingType_Setup FabricDyeingType { get; set; }
        public virtual FabricGuage_Setup FabricGuage { get; set; }
        public virtual FabricMachineType_Setup FabricMachineType { get; set; }
        public virtual FabricQuality_Setup FabricQuality { get; set; }
        public virtual ICollection<GreigeFabricTippingVeltSpecification> GreigeFabricTippingVeltSpecification { get; set; }
        public virtual ICollection<GreigeFabricYarnSpecification> GreigeFabricYarnSpecification { get; set; }
    }
}
