using RG.DBEntities.Maxco.Setup;
using System;
using System.Collections.Generic;
using System.Text;

namespace RG.DBEntities.Maxco.Trims
{
   public class SelectedTrim
    {
        public SelectedTrim()
        {
            BeadSpecification = new HashSet<BeadSpecification>();
            BuckleSpecification = new HashSet<BuckleSpecification>();
            ButtonSpecification = new HashSet<ButtonSpecification>();
           // ChordHolderSpecification = new HashSet<ChordHolderSpecification>();
           HangTagSpecification = new HashSet<HangTagSpecification>();
            LabelSpecification = new HashSet<LabelSpecification>();
            LaceSpecification = new HashSet<LaceSpecification>();
           // NetMeshSpecification = new HashSet<NetMeshSpecification>();
          //  RivetSpecification = new HashSet<RivetSpecification>();
        }

        public long ID { get; set; }
        public int TrimID { get; set; }
        public int Status { get; set; }
        public int SelectedElementID { get; set; }

        // public virtual SelectedElement SelectedElement { get; set; }
        public virtual Trim_Setup Trim { get; set; }
        public virtual ICollection<BeadSpecification> BeadSpecification { get; set; }
        public virtual ICollection<BuckleSpecification> BuckleSpecification { get; set; }
        public virtual ICollection<ButtonSpecification> ButtonSpecification { get; set; }
      //  public virtual ICollection<ChordHolderSpecification> ChordHolderSpecification { get; set; }
        public virtual ICollection<HangTagSpecification> HangTagSpecification { get; set; }
        public virtual ICollection<LabelSpecification> LabelSpecification { get; set; }
        public virtual ICollection<LaceSpecification> LaceSpecification { get; set; }
      //  public virtual ICollection<NetMeshSpecification> NetMeshSpecification { get; set; }
      //  public virtual ICollection<RivetSpecification> RivetSpecification { get; set; }
    }
}
