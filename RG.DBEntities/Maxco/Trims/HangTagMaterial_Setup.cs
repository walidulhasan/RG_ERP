using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Trims
{
    public partial class HangTagMaterial_Setup
    {
        public HangTagMaterial_Setup()
        {
            HangTagSpecification = new HashSet<HangTagSpecification>();
        }

        public int ID { get; set; }
        public string Description { get; set; }

       public virtual ICollection<HangTagSpecification> HangTagSpecification { get; set; }
    }
}
