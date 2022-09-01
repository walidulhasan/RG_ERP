
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using RG.DBEntities.Maxco.Business;
using RG.DBEntities.Maxco.Setup;
using RG.DBEntities.Maxco.Trims;


namespace RG.DBEntities.Maxco.FabricAndYarn
{
    public partial class FabricSpecification 
    {
        public FabricSpecification()
        {
            //CollarSpecification = new HashSet<CollarSpecification>();
            //FabricFinishingProcessSpecification = new HashSet<FabricFinishingProcessSpecification>();
            //FabricPlacementInstructionSelected = new HashSet<FabricPlacementInstructionSelected>();
            //FabricSelectedFinishingPropertiesValue = new HashSet<FabricSelectedFinishingPropertiesValue>();
            FabricSpecificationColor = new HashSet<FabricSpecificationColor>();
            //FabricSpecificationFinishing = new HashSet<FabricSpecificationFinishing>();
            //FabricSpecificationWashing = new HashSet<FabricSpecificationWashing>();
            //FabricTippingVeltSpecification = new HashSet<FabricTippingVeltSpecification>();
            FabricTrimDimensions = new HashSet<FabricTrimDimensions>();
            FabricTrimPlacementInstruction = new HashSet<FabricTrimPlacementInstruction>();
           // FabricTrimSpecification = new HashSet<FabricTrimSpecification>();
            FabricWashingFinishingSpecification = new HashSet<FabricWashingFinishingSpecification>();
            FabricYarnSpecification = new HashSet<FabricYarnSpecification>();
            //FabricYarnTwistingSpecification = new HashSet<FabricYarnTwistingSpecification>();
            FC_ModelFabricGroups = new HashSet<FC_ModelFabricGroups>();
            //InverseColorParent = new HashSet<FabricSpecification>();
            //InverseFabricParent = new HashSet<FabricSpecification>();
            PatternPieceSpecification = new HashSet<PatternPieceSpecification>();
            FabricTrimSpecification = new FabricTrimSpecification();
        }

        public long ID { get; set; }

        public long? FabricSpecificationSetupID { get; set; }
        [ForeignKey("FabricQuality_Setup")]
        public int? QualityID { get; set; }
        public int? GSM { get; set; }
        [ForeignKey("FabricMachineType_Setup")]
        public int? MachineTypeID { get; set; }
        [ForeignKey("FabricGuage_Setup")]
        public int? GaugeID { get; set; }
        [ForeignKey("FabricDyeingType_Setup")]
        public int? DyeingID { get; set; }
        public int? ShrinkageWidth { get; set; }
        public int? ShrinkageLength { get; set; }
        //[ForeignKey("FabricSpecification")]
        public long? FabricParentID { get; set; }
        [ForeignKey("FabricImageSetup")]
        public int? ImageID { get; set; }
        //[ForeignKey("FabricSpecification")]
        public long ColorParentID { get; set; }
        [ForeignKey("FabricTrimSelected")]
        public int? FabricTrimSelectedID { get; set; }
        public int? PalleteTypeID { get; set; }
        public bool? IsSpandex { get; set; }
        public string Comments { get; set; }
        public double? FinishedWidth { get; set; }
        [ForeignKey("FabricColorMatchingSource_Setup")]
        public int? MatchingSourceID { get; set; }
        public bool? IsFinishingRequired { get; set; }
        public int? Spandex { get; set; }
        public string FabricComposition { get; set; }
        [ForeignKey("DenimWeightSetup")]
        public int? DenimWeightID { get; set; }
        public int? FabricCategoryID { get; set; }
        [ForeignKey("WovenConstructionSetup")]
        public int? WovenConstructionID { get; set; }
        [ForeignKey("WovenCompositionSetup")]
        public int? WovenCompositionID { get; set; }
        public int? NoOfWales { get; set; }
        public bool? IsDivisor { get; set; }
        public int? DivisorLength { get; set; }
        public string SizeRangeComments { get; set; }
        public int? FastnessStandardID { get; set; }
        public int? PrintImageID { get; set; }
        public int? DenimBuyerID { get; set; }
        public string DenimBuyerCode { get; set; }
        public int? FabricTension { get; set; }
        public int? FlatKnitTopEndID { get; set; }
        public int? FlatKnitBottomEndID { get; set; }
        public int? UserSelectedUnitID { get; set; }
        public long? FinishFabricCodeID { get; set; }
        public int? ProcurementUnitID { get; set; }
        public int? WeaveTypeID { get; set; }


        //public virtual FabricSpecification ColorParent { get; set; }
        public virtual DenimWeight_Setup DenimWeight { get; set; }
        public virtual FabricDyeingType_Setup Dyeing { get; set; }
        //public virtual FabricSpecification FabricParent { get; set; }
        public virtual FabricTrimSelected FabricTrimSelected { get; set; }
        public virtual FabricGuage_Setup FabricGuage_Setup { get; set; }
        public virtual FabricImage_Setup Image { get; set; }
        public virtual FabricMachineType_Setup MachineType { get; set; }
        public virtual FabricColorMatchingSource_Setup FabricColorMatchingSource_Setup { get; set; }
        public virtual FabricQuality_Setup Quality { get; set; }
        public virtual WovenComposition_Setup WovenComposition { get; set; }
        public virtual WovenConstruction_Setup WovenConstruction { get; set; }
        //   public virtual ICollection<CollarSpecification> CollarSpecification { get; set; }
        //  public virtual ICollection<FabricFinishingProcessSpecification> FabricFinishingProcessSpecification { get; set; }
        //   public virtual ICollection<FabricPlacementInstructionSelected> FabricPlacementInstructionSelected { get; set; }
        //  public virtual ICollection<FabricSelectedFinishingPropertiesValue> FabricSelectedFinishingPropertiesValue { get; set; }
        public virtual ICollection<FabricSpecificationColor> FabricSpecificationColor { get; set; }
        //  public virtual ICollection<FabricSpecificationFinishing> FabricSpecificationFinishing { get; set; }
        //   public virtual ICollection<FabricSpecificationWashing> FabricSpecificationWashing { get; set; }
        //   public virtual ICollection<FabricTippingVeltSpecification> FabricTippingVeltSpecification { get; set; }
        public virtual ICollection<FabricTrimDimensions> FabricTrimDimensions { get; set; }
        public virtual ICollection<FabricTrimPlacementInstruction> FabricTrimPlacementInstruction { get; set; }
     //  public virtual ICollection<FabricTrimSpecification> FabricTrimSpecification { get; set; }
        public virtual FabricTrimSpecification FabricTrimSpecification { get; set; }
        public virtual ICollection<FabricWashingFinishingSpecification> FabricWashingFinishingSpecification { get; set; }
        public virtual ICollection<FabricYarnSpecification> FabricYarnSpecification { get; set; }
        //public virtual ICollection<FabricYarnTwistingSpecification> FabricYarnTwistingSpecification { get; set; }
        public virtual ICollection<FC_ModelFabricGroups> FC_ModelFabricGroups { get; set; }
        //public virtual ICollection<FabricSpecification> InverseColorParent { get; set; }
        //public virtual ICollection<FabricSpecification> InverseFabricParent { get; set; }
        public virtual ICollection<PatternPieceSpecification> PatternPieceSpecification { get; set; }
    }
}
