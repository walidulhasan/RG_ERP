using System;
using System.Collections.Generic;
using RG.DBEntities.Maxco.Trims;
using RG.DBEntities.Maxco.FabricAndYarn;

namespace RG.DBEntities.Maxco.Setup
{
    public partial class ProcurementSource_Setup
    {
        public ProcurementSource_Setup()
        {
            BeadSpecification = new HashSet<BeadSpecification>();
            BuckleSpecification = new HashSet<BuckleSpecification>();
            ButtonSpecification = new HashSet<ButtonSpecification>();
            ChordHolderSpecification = new HashSet<ChordHolderSpecification>();
            EyeletSpecification = new HashSet<EyeletSpecification>();
            HangTagSpecification = new HashSet<HangTagSpecification>();
            LabelSpecification = new HashSet<LabelSpecification>();
            LaceSpecification = new HashSet<LaceSpecification>();
            //NetMeshSpecification = new HashSet<NetMeshSpecification>();
            //VelcroSpecification = new HashSet<VelcroSpecification>();
            //ZipSpecification = new HashSet<ZipSpecification>();
        }

        public int ID { get; set; }
        public string Description { get; set; }

        public virtual ICollection<BeadSpecification> BeadSpecification { get; set; }
        public virtual ICollection<BuckleSpecification> BuckleSpecification { get; set; }
        public virtual ICollection<ButtonSpecification> ButtonSpecification { get; set; }
        public virtual ICollection<ChordHolderSpecification> ChordHolderSpecification { get; set; }
        public virtual ICollection<EyeletSpecification> EyeletSpecification { get; set; }
        public virtual ICollection<HangTagSpecification> HangTagSpecification { get; set; }
        public virtual ICollection<LabelSpecification> LabelSpecification { get; set; }
        public virtual ICollection<LaceSpecification> LaceSpecification { get; set; }
       // public virtual ICollection<NetMeshSpecification> NetMeshSpecification { get; set; }
      //  public virtual ICollection<VelcroSpecification> VelcroSpecification { get; set; }
      //  public virtual ICollection<ZipSpecification> ZipSpecification { get; set; }
    }
}
