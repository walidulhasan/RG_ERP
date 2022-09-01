using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Trims
{
    public partial class PolyBagSpecification
    {
        public PolyBagSpecification()
        {
            PolyBagSize = new HashSet<PolyBagSize>();
        }
        public long ID { get; set; }
        public int ImageID { get; set; }
        public int MaterialID { get; set; }
        public int? UserID { get; set; }
        public int? VarianceTypeID { get; set; }
        public int? TrimID { get; set; }
        public long? StyleID { get; set; }
        public long? FabricSpecificationID { get; set; }
        public int ThicknessID { get; set; }
        public bool IsPrinting { get; set; }
        public int? PrintingTypeID { get; set; }
        public bool IsFlap { get; set; }
        public bool? IsHangerCut { get; set; }
        public bool? IsOpeningHangerCut { get; set; }
        public int? FlapTypeID { get; set; }
        public int? AdhesiveTypeID { get; set; }
        public bool? IsMeasurement { get; set; }
        public string Comments { get; set; }
        public long SelectedTrimID { get; set; }
        public int? DesignID { get; set; }
        public int? GussetID { get; set; }
        public bool? IsAirHole { get; set; }
        public double? UsePerPiece { get; set; }
        public int? TrimStatus { get; set; }
        public bool? IsMasterPolyBag { get; set; }
        public int? ProcurementSourceID { get; set; }

        public ICollection<PolyBagSize> PolyBagSize { get; set; }
    }
}
