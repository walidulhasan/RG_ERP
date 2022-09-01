using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class CmblStatusPo
    {
        [Key]
        public int StatusId { get; set; }
        public string Description { get; set; }
    }
}
