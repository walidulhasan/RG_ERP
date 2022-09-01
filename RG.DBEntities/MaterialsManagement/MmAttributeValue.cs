using System;
using System.Collections.Generic;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class MmAttributeValue
    {
        public long AttributeValueId { get; set; }
        public int AttributeId { get; set; }
        public int MavalueId { get; set; }
        public string MavalueDescription { get; set; }
    }
}
