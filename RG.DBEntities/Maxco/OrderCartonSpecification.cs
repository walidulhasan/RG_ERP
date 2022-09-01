using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class OrderCartonSpecification
    {
        public int Id { get; set; }
        public bool IsMaster { get; set; }
        public bool IsMeasurement { get; set; }
        public byte CartonTypeId { get; set; }
        public byte? ConstraintId { get; set; }
        public byte? NoOfPlies { get; set; }
        public double? Length { get; set; }
        public double? Width { get; set; }
        public double? Height { get; set; }
        public bool IsInch { get; set; }
        public bool IsCourrugation { get; set; }
        public byte? CorrugationNo { get; set; }
        public bool IsPrinting { get; set; }
        public byte? PrintingType { get; set; }
        public byte? CartonPrintingFaceId { get; set; }
        public bool IsGreenDot { get; set; }
        public bool IsRecylingLogo { get; set; }
        public bool IsSampling { get; set; }
        public DateTime? SamplingDate { get; set; }
        public string Comments { get; set; }
        public byte? SamplingStatus { get; set; }
        public byte VersionNo { get; set; }
        public int ShipmentPackingId { get; set; }
        public short? NoOfInnerPacks { get; set; }
        public bool? IsInnerRqd { get; set; }
    }
}
