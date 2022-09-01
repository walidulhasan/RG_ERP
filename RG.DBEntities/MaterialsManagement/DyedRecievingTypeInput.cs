using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class DyedRecievingTypeInput
    {
        [Key]
        public long TypeId { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
    }
}
