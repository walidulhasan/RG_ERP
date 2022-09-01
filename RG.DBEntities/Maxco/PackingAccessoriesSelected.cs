using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class PackingAccessoriesSelected
    {
        public short Id { get; set; }
        public short PackingAccessoryId { get; set; }
        public short PackingTypeId { get; set; }
        public string Description { get; set; }
        public int StyleId { get; set; }
        public short FieldType { get; set; }
    }
}
