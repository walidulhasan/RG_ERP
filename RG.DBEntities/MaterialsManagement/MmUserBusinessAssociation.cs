using System;
using System.Collections.Generic;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class MmUserBusinessAssociation
    {
        public int Id { get; set; }
        public long UserId { get; set; }
        public long BusinessId { get; set; }
    }
}
