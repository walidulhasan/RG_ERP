using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class MmGeneralSetupDetail
    {
        [Key]
        public string SetupId { get; set; }
        public string InstanceId { get; set; }
        public int CompanyId { get; set; }
        public string InstanceValue { get; set; }
        public string Description { get; set; }
        public DateTime Rdate { get; set; }
    }
}
