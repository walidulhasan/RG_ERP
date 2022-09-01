using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class BciMainComboDetail
    {
        [Key]
        public decimal ComboDetailId { get; set; }
        public string Style { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
        public long? Quantity { get; set; }
        public decimal? ComboId { get; set; }
    }
}
