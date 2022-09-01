using System;
using System.Collections.Generic;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class IcUserMenuItem
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public long MenuItemId { get; set; }
        public long AssignedBy { get; set; }
        public DateTime? AssignedOn { get; set; }
    }
}
