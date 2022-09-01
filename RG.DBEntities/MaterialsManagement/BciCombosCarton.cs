using System;
using System.Collections.Generic;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class BciCombosCarton
    {
        public decimal Id { get; set; }
        public decimal CartonId { get; set; }
        public decimal? ComboId { get; set; }
    }
}
