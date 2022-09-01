using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class ModelPackingAccessories
    {
        public int Id { get; set; }
        public long StyleId { get; set; }
        public string PackingXml { get; set; }
    }
}
