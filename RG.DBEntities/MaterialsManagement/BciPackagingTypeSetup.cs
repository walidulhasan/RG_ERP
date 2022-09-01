using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class BciPackagingTypeSetup
    {
        [Key]
        public int PackagingTypeId { get; set; }
        public string PackagingType { get; set; }
    }
}
