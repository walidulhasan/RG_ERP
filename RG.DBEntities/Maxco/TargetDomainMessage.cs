using System;
using System.Collections.Generic;
using RG.DBEntities.Maxco.Setup;
using RG.DBEntities.Maxco.FabricAndYarn;
using RG.DBEntities.Maxco.Trims;

namespace RG.DBEntities.Maxco
{
    public partial class TargetDomainMessage
    {
        public int Id { get; set; }
        public int TargetDomainId { get; set; }
        public int GeneratedMessageId { get; set; }
        public int Status { get; set; }
        public DateTime? ViewingDate { get; set; }

        public virtual TargetDomainSetup TargetDomain { get; set; }
    }
}
