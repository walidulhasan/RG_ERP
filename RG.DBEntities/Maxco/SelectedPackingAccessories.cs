using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class SelectedPackingAccessories
    {
        public int Id { get; set; }
        public short PackingAccessoriesId { get; set; }
        public byte Status { get; set; }
        public int SelectedElementId { get; set; }
    }
}
