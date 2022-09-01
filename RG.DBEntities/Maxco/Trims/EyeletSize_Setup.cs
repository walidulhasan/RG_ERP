using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Trims
{
    public partial class EyeletSize_Setup
    {
        public EyeletSize_Setup()
        {
            EyeletSpecification = new HashSet<EyeletSpecification>();
        }

        public int ID { get; set; }
        public string Description { get; set; }

        public virtual ICollection<EyeletSpecification> EyeletSpecification { get; set; }
    }
}
