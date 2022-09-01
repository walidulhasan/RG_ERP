using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class CmblItemMaster
    {
        [Key]
        public long ItemMasterId { get; set; }
        public string ItemName { get; set; }
        public long? UnitId { get; set; }
    }
}
