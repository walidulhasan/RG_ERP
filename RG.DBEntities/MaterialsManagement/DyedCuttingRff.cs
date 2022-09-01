using System;
using System.Collections.Generic;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class DyedCuttingRff
    {
        public int Id { get; set; }
        public DateTime DocumentDate { get; set; }
        public int? UserId { get; set; }
    }
}
