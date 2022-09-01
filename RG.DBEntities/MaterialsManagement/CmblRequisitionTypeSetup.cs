using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class CmblRequisitionTypeSetup
    {
        [Key]
        public int ReqTypeId { get; set; }
        public string Description { get; set; }
    }
}
