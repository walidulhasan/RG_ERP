using System;
using System.Collections.Generic;

using RG.DBEntities.Maxco.Setup;
 
using RG.DBEntities.Maxco.FabricAndYarn;

namespace RG.DBEntities.Maxco.Trims
{
    public partial class RivetSpecification
    {
        public RivetSpecification()
        {
            RivetColor = new HashSet<RivetColor>();
            RivetPlacementInstruction = new HashSet<RivetPlacementInstruction>();
        }

        public int Id { get; set; }
        public int ImageId { get; set; }
        public bool? IsMetalFinish { get; set; }
        public byte SizeId { get; set; }
        public byte? UsePerPiece { get; set; }
        public byte ProcurementSourceId { get; set; }
        public long SelectedTrimId { get; set; }
        public byte VersionNo { get; set; }
        public byte Status { get; set; }
        public string Comments { get; set; }
        public int? MeasurementScaleId { get; set; }
        public byte? NoOfParts { get; set; }
        public byte InsertionId { get; set; }
        public string TechComments { get; set; }
        public int? DesignTypeId { get; set; }
        public int? TrimStatus { get; set; }

        public virtual RivetImageSetup Image { get; set; }
        public virtual TrimMeasurementScale_Setup MeasurementScale { get; set; }
        public virtual SelectedTrim SelectedTrim { get; set; }
        public virtual RivetSizeSetup Size { get; set; }
        public virtual ICollection<RivetColor> RivetColor { get; set; }
        public virtual ICollection<RivetPlacementInstruction> RivetPlacementInstruction { get; set; }
    }
}
