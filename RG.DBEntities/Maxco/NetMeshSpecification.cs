using System;
using System.Collections.Generic;
using RG.DBEntities.Maxco.Setup;
using RG.DBEntities.Maxco.Trims;
using RG.DBEntities.Maxco.FabricAndYarn;

namespace RG.DBEntities.Maxco
{
    public partial class NetMeshSpecification
    {
        public NetMeshSpecification()
        {
            NetMeshColor = new HashSet<NetMeshColor>();
            NetMeshPlacementInstruction = new HashSet<NetMeshPlacementInstruction>();
        }

        public int Id { get; set; }
        public int ImageId { get; set; }
        public byte TypeId { get; set; }
        public byte WidthId { get; set; }
        public double? Consumption { get; set; }
        public byte? TrimMeasurementScaleId { get; set; }
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

        public virtual NetMeshDyeingSetup Dyed { get; set; }
        public virtual NetMeshImageSetup Image { get; set; }
        public virtual ProcurementSource_Setup ProcurementSource { get; set; }
        public virtual SelectedTrim SelectedTrim { get; set; }
        public virtual NetMeshTypeSetup Type { get; set; }
        public virtual NetMeshWidthSetup Width { get; set; }
        public virtual ICollection<NetMeshColor> NetMeshColor { get; set; }
        public virtual ICollection<NetMeshPlacementInstruction> NetMeshPlacementInstruction { get; set; }
    }
}
