using System;
using System.Collections.Generic;
using RG.DBEntities.Maxco.Setup;
using RG.DBEntities.Maxco.Trims;
using RG.DBEntities.Maxco.FabricAndYarn;

namespace RG.DBEntities.Maxco
{
    public partial class VelcroSpecification
    {
        public VelcroSpecification()
        {
            VelcroColor = new HashSet<VelcroColor>();
            VelcroPlacementInstruction = new HashSet<VelcroPlacementInstruction>();
        }

        public int Id { get; set; }
        public int ImageId { get; set; }
        public byte WidthId { get; set; }
        public double? Consumption { get; set; }
        public short? TrimMeasurementScaleId { get; set; }
        public long SelectedTrimId { get; set; }
        public byte VersionNo { get; set; }
        public byte Status { get; set; }
        public string Comments { get; set; }
        public int ProcurementSourceId { get; set; }
        public byte? DyedId { get; set; }
        public byte? WidthMeasurementScaleId { get; set; }
        public byte InsertionId { get; set; }
        public string TechComments { get; set; }
        public int? DesignTypeId { get; set; }
        public int? TrimStatus { get; set; }

        public virtual VelcroDyeingSetup Dyed { get; set; }
        public virtual VelcroImageSetup Image { get; set; }
        public virtual ProcurementSource_Setup ProcurementSource { get; set; }
        public virtual VelcroWidthSetup Width { get; set; }
        public virtual ICollection<VelcroColor> VelcroColor { get; set; }
        public virtual ICollection<VelcroPlacementInstruction> VelcroPlacementInstruction { get; set; }
    }
}
