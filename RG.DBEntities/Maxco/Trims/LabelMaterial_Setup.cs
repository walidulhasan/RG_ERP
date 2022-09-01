using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Trims
{
    public partial class LabelMaterial_Setup
    {
        public LabelMaterial_Setup()
        {
            LabelSpecification = new HashSet<LabelSpecification>();
        }

        public int ID { get; set; }
        public string Description { get; set; }

        public virtual ICollection<LabelSpecification> LabelSpecification { get; set; }
    }
}
