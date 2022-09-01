using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class IcvpopulateTableTemp
    {
        [Key]
        public long VoucherId { get; set; }
        public long RefNo { get; set; }
        public int? FabricCategoryId { get; set; }
    }
}
