using System;
using System.Collections.Generic;
using RG.DBEntities.Maxco.Trims;
using RG.DBEntities.Maxco.FabricAndYarn;

namespace RG.DBEntities.Maxco.Setup
{
    public partial class TrimMeasurementScale_Setup
    {
        public TrimMeasurementScale_Setup()
        {
            BuckleSpecification = new HashSet<BuckleSpecification>();
            ChordHolderSpecification = new HashSet<ChordHolderSpecification>();
            LabelSpecification = new HashSet<LabelSpecification>();
           // LaceSpecification = new HashSet<LaceSpecification>();
            RivetSpecification = new HashSet<RivetSpecification>();
            ZipSpecification = new HashSet<ZipSpecification>();
        }

        public int TrimID { get; set; }
        public int MeasurementScaleID { get; set; }
        public int ID { get; set; }

        public virtual MeasurementScale_Setup MeasurementScale { get; set; }
        public virtual ICollection<BuckleSpecification> BuckleSpecification { get; set; }
        public virtual ICollection<ChordHolderSpecification> ChordHolderSpecification { get; set; }
        public virtual ICollection<LabelSpecification> LabelSpecification { get; set; }
       // public virtual ICollection<LaceSpecification> LaceSpecification { get; set; }
        public virtual ICollection<RivetSpecification> RivetSpecification { get; set; }
        public virtual ICollection<ZipSpecification> ZipSpecification { get; set; }
    }
}
