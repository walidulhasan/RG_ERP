using System;
using System.Collections.Generic;
using System.Text;

namespace RG.DBEntities.Maxco.Trims
{
    public class TrimPlacementInstruction_Setup
    {
        public TrimPlacementInstruction_Setup()
        {
            BucklePlacementInstruction = new HashSet<BucklePlacementInstruction>();
           // ElasticPlacementInstruction = new HashSet<ElasticPlacementInstruction>();
            EyeletPlacementInstruction = new HashSet<EyeletPlacementInstruction>();
            LabelPlacementInstruction = new HashSet<LabelPlacementInstruction>();
            SequencePlacementInstruction = new HashSet<SequencePlacementInstruction>();
            ThreadPlacementInstruction = new HashSet<ThreadPlacementInstruction>();
            ZipPlacementInstruction = new HashSet<ZipPlacementInstruction>();
        }

        public int ID { get; set; }
        public byte TrimID { get; set; }
        public string Description { get; set; }
        public int? UsePerPiece { get; set; }

        public virtual Trim_Setup Trim { get; set; }
        public virtual ICollection<BucklePlacementInstruction> BucklePlacementInstruction { get; set; }
    //    public virtual ICollection<ElasticPlacementInstruction> ElasticPlacementInstruction { get; set; }
        public virtual ICollection<EyeletPlacementInstruction> EyeletPlacementInstruction { get; set; }
        public virtual ICollection<LabelPlacementInstruction> LabelPlacementInstruction { get; set; }
        public virtual ICollection<SequencePlacementInstruction> SequencePlacementInstruction { get; set; }
        public virtual ICollection<ThreadPlacementInstruction> ThreadPlacementInstruction { get; set; }
        public virtual ICollection<ZipPlacementInstruction> ZipPlacementInstruction { get; set; }
    }
}
