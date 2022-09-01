using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Trims
{
    public partial class PolyBagSpecificationInOrder
    {
        public int Id { get; set; }
        public int PolyBagId { get; set; }
        public int? PolyBagImageId { get; set; }
        public bool IsSinglePiece { get; set; }
        public bool IsSizeWise { get; set; }
        public int MaterialId { get; set; }
        public bool IsFlap { get; set; }
        public int? FlapId { get; set; }
        public bool IsHangerCut { get; set; }
        public bool? IsOpeningHangerCut { get; set; }
        public int AdhesiveId { get; set; }
        public string Thickness { get; set; }
        public bool IsPrinting { get; set; }
        public short? PrintingId { get; set; }
        public bool IsDot { get; set; }
        public bool IsLogo { get; set; }
        public string Comments { get; set; }
    }
}
