using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class MmDomainCategory
    {
        [Key]
        public int? DomainId { get; set; }
        public int? StoreCategoryId { get; set; }
    }
}
