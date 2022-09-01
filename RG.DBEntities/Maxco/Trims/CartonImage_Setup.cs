using System;
using System.Collections.Generic;
using System.Text;

namespace RG.DBEntities.Maxco.Trims
{
    public class CartonImage_Setup
    {
        public int ID { get; set; }
        public string ImagePath { get; set; }
        public string Code { get; set; }
        public DateTime? CreationDate { get; set; }
        public int? TrimID { get; set; }
        public int? CartonTypeID { get; set; }
        public int? NoOfPliesID { get; set; }
        public double? Length { get; set; }
        public double? Width { get; set; }
        public double? Height { get; set; }
        public int? IsCorrugated { get; set; }
        public int? NoOfCorrugation { get; set; }
        public int? IsPrintingRequired { get; set; }
        public string PrintingImagePath { get; set; }
        public int? PrintingTypeID { get; set; }
        public int? PrintedFaceID { get; set; }
        public int? IsGreenDotRequired { get; set; }
        public int? IsRecyclingLogo { get; set; }
        public int? IsCartonTape { get; set; }
        public int? IsBaleStrip { get; set; }
        public int? CollectionId { get; set; }
        public double? Price { get; set; }
        public double? FOB { get; set; }
        public double? Frieght { get; set; }
        public double? Duty { get; set; }
        public double? CLRTotal { get; set; }
        public string UserCode { get; set; }
        public int? VendorID { get; set; }
        public int? UserID { get; set; }
    }
}
