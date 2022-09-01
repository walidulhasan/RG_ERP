using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class ComboComboStyle
    {
        [Key]
        public long ComboDetailId { get; set; }
        public string ComboStyleCode { get; set; }
        public long Quantity { get; set; }
    }
}
