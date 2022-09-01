using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class TblWorkCenterAttributesDetail
    {
        [Key]
        public long Wcaid { get; set; }
        public int FabricCategoryId { get; set; }

        public virtual TblWorkCenterAttributes Wca { get; set; }
    }
}
