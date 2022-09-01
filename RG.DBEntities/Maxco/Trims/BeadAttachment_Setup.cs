using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Trims
{
    public partial class BeadAttachment_Setup
    {
        public BeadAttachment_Setup()
        {
            BeadSpecification = new HashSet<BeadSpecification>();
        }

        public int ID { get; set; }
        public string Description { get; set; }

        public virtual ICollection<BeadSpecification> BeadSpecification { get; set; }
    }
}
