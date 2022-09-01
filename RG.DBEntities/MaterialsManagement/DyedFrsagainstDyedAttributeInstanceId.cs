using System;
using System.Collections.Generic;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class DyedFrsagainstDyedAttributeInstanceId
    {
        public long Id { get; set; }
        public long FrsattributeInstanceId { get; set; }
        public long DyedAttributeInstanceId { get; set; }
    }
}
