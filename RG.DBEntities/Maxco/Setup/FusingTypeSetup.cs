using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Setup
{
    public partial class FusingTypeSetup
    {
        public FusingTypeSetup()
        {
            FusingSpecification = new HashSet<FusingSpecification>();
        }

        public int Id { get; set; }
        public string Description { get; set; }

        public virtual ICollection<FusingSpecification> FusingSpecification { get; set; }
    }
}
