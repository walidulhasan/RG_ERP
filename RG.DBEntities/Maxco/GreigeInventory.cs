using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.Maxco
{
    public partial class GreigeInventory
    {[Key]
        public int GreigeInventoryId { get; set; }
        public int MrpitemCode { get; set; }
        public long AttributeInstanceId { get; set; }
    }
}
