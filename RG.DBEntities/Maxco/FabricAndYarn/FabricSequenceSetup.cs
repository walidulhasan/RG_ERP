using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.FabricAndYarn
{
    public partial class FabricSequenceSetup
    {
        public FabricSequenceSetup()
        {
            SequenceSpecification = new HashSet<SequenceSpecification>();
        }

        public int Id { get; set; }
        public string Description { get; set; }

        public virtual ICollection<SequenceSpecification> SequenceSpecification { get; set; }
    }
}
