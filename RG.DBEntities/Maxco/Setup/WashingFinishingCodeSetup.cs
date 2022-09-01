using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Setup
{
    public partial class WashingFinishingCodeSetup
    {
        public WashingFinishingCodeSetup()
        {
            WashingFinishingCodeSetupMapping = new HashSet<WashingFinishingCodeSetupMapping>();
        }

        public long Id { get; set; }
        public string Code { get; set; }
        public int FabricCategoryId { get; set; }
        public int ProcessTypeId { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual ICollection<WashingFinishingCodeSetupMapping> WashingFinishingCodeSetupMapping { get; set; }
    }
}
