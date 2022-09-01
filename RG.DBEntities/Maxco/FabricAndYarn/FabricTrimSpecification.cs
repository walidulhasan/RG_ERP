using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using RG.DBEntities.Maxco.Setup;
using RG.DBEntities.Maxco.Trims;


namespace RG.DBEntities.Maxco.FabricAndYarn
{
    public partial class FabricTrimSpecification
    {
        public int ID { get; set; }
        [ForeignKey("FabricSpecification")]
        public long? FabricSpecificationID { get; set; }
        public int? TrimDesignID { get; set; }
        public bool? IsPointed { get; set; }
        public bool? IsFolded { get; set; }
        public string OpeningDiameter { get; set; }
        public int? RollWidthID { get; set; }
        public int? ConstructionID { get; set; }
        public bool? IsFuseable { get; set; }
        public double? Size { get; set; }
        public bool? IsPatch { get; set; }
        public bool? IsFlap { get; set; }
        public int? TrimMeasurementScaleID { get; set; }
        [ForeignKey("InterLinningTypes_Setup")]
        public int? InterlinningType { get; set; }
        public double? ConsumptionPerPiece { get; set; }
        [ForeignKey("PlacketType_Setup")]
        public int? PlacketTypeID { get; set; }
        public bool? IsHoodSingle { get; set; }
        public bool? IsHoodFabricSame { get; set; }
        public string Comments { get; set; }
        public int? IsLeather { get; set; }
        public int? InterlinningSolubleType { get; set; }
        public double? Length { get; set; }
        public double? Width { get; set; }
        public int? Color { get; set; }

        public virtual FabricSpecification FabricSpecification { get; set; }
        public virtual InterLinningTypes_Setup InterLinningTypes_Setup { get; set; }
        public virtual PlacketType_Setup PlacketType_Setup { get; set; }
    }
}
