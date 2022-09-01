using System;
using System.Collections.Generic;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class YarnStvissuanceAssociation
    {
        public long AssociationId { get; set; }
        public string Stv { get; set; }
        public string IssuanceId { get; set; }
        public long? Ykcid { get; set; }
        public long? UserId { get; set; }
    }
}
