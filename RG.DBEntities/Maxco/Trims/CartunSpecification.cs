using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Trims
{
    public partial class CartunSpecification
    {
        public int ID { get; set; }
        public int? ImageID { get; set; }
        public int? UserID { get; set; }
        public long? FabricSpecificationId { get; set; }
        public long? StyleID { get; set; }
        public int? ProcurementSourceID { get; set; }
        public int? TrimID { get; set; }
        public int? TrimStatus { get; set; }
        public int? CartonTypeID { get; set; }
        public int? NoOfPliesID { get; set; }
        public double? Length { get; set; }
        public double? Width { get; set; }
        public double? Height { get; set; }
        public int? IsCorrugated { get; set; }
        public int? NoOfCorrugation { get; set; }
        public int? IsPrintingRequired { get; set; }
        public int? PrintingTypeID { get; set; }
        public int? PrintedFaceID { get; set; }
        public int? IsGreenDotRequired { get; set; }
        public int? IsRecyclingLogo { get; set; }
        public int? IsCartonTape { get; set; }
        public int? IsBaleStrip { get; set; }
        public string Comments { get; set; }
        public long? SelectedTrimID { get; set; }
        public double? UsePerPiece { get; set; }
    }
}
