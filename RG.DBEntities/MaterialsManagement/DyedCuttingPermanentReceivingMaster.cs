using System;
using System.Collections.Generic;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class DyedCuttingPermanentReceivingMaster
    {
        public long PermRecId { get; set; }
        public DateTime PermRecDate { get; set; }
        public int Status { get; set; }
        public string PermRecNo { get; set; }
        public long Ciid { get; set; }
        public int? UserId { get; set; }
    }
}
