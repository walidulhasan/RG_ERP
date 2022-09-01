using System;
using System.Collections.Generic;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class IcMenuItem
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string NavigateUrl { get; set; }
        public byte ItemType { get; set; }
        public long? ParentItemId { get; set; }
        public long? DocumentId { get; set; }
    }
}
