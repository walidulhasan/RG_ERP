using System;
using System.Collections.Generic;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class DdmrpitemSetup
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int MrpitemCode { get; set; }
        public int ItemCatagoryId { get; set; }
    }
}
