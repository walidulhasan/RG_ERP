using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class ComboComboDetail
    {
        [Key]
        public long ComboDetailId { get; set; }
        public string ComboDetailCode { get; set; }
        public long ComboId { get; set; }
    }
}
