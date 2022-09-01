using System;
using System.Collections.Generic;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class DyedStockRolls
    {
        public int Id { get; set; }
        public string RollNo { get; set; }
        public int DocumentNo { get; set; }
        public int DocumentTypeId { get; set; }
    }
}
