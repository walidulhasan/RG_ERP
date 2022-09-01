using System;
using System.Collections.Generic;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class YarnWoissRecAssociate
    {
        public long Id { get; set; }
        public long? YarnWoid { get; set; }
        public long? YarnWoissDetailId { get; set; }
        public long? YarnWorecDetailId { get; set; }
    }
}
