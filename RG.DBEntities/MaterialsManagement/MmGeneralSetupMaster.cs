using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class MmGeneralSetupMaster
    {
        [Key]
        public string SetupId { get; set; }
        public string Description { get; set; }
        public DateTime Rdate { get; set; }
    }
}
