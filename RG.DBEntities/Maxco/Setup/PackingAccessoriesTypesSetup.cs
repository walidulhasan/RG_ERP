using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Setup
{
    public partial class PackingAccessoriesTypesSetup
    {
        public short Id { get; set; }
        public short PackingAccessoryId { get; set; }
        public string Description { get; set; }
        public short FieldType { get; set; }

        public virtual PackingAccessoriesSetup PackingAccessory { get; set; }
    }
}
