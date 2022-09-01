using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class BciComboDetails
    {
        [Key]
        public long ComboDetailId { get; set; }
        public string ComboStyleNo { get; set; }
        public string ComboColor { get; set; }
        public string ComboSize { get; set; }
        public string Style { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
        public int? Quantity { get; set; }
        public int? ComboId { get; set; }
    }
}
