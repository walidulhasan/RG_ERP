using System;
using System.Collections.Generic;
using RG.DBEntities.Maxco.Setup;
using RG.DBEntities.Maxco.FabricAndYarn;
using RG.DBEntities.Maxco.Trims;

namespace RG.DBEntities.Maxco
{
    public partial class SequenceSpecification
    {
        public SequenceSpecification()
        {
            SequencePlacementInstruction = new HashSet<SequencePlacementInstruction>();
        }

        public int Id { get; set; }
        public int NoOfMaterials { get; set; }
        public int FabricSequenceId { get; set; }
        public string Comments { get; set; }
        public int SelectedTrimId { get; set; }
        public byte VersionNo { get; set; }
        public byte Status { get; set; }
        public bool IsThreading { get; set; }
        public int ImageId { get; set; }
        public int NoOfPlacementInstructions { get; set; }
        public int? FabricSpecificationId { get; set; }
        public byte InsertionId { get; set; }
        public string TechComments { get; set; }
        public int? DesignTypeId { get; set; }
        public int? TrimStatus { get; set; }

        public virtual FabricSequenceSetup FabricSequence { get; set; }
        public virtual SequenceImageSetup Image { get; set; }
        public virtual ICollection<SequencePlacementInstruction> SequencePlacementInstruction { get; set; }
    }
}
