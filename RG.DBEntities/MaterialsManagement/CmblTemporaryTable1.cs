using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class CmblTemporaryTable1
    {
        [Key]
        public long ItemId { get; set; }
        public int ItemTypeId { get; set; }
        public int UnitId { get; set; }
    }
}
