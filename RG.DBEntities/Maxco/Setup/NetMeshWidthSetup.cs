using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Setup
{
    public partial class NetMeshWidthSetup
    {
        public NetMeshWidthSetup()
        {
            NetMeshSpecification = new HashSet<NetMeshSpecification>();
        }

        public byte Id { get; set; }
        public string Description { get; set; }

        public virtual ICollection<NetMeshSpecification> NetMeshSpecification { get; set; }
    }
}
