using System;
using System.Collections.Generic;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class DdnonmrpitemSetup
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int MrpitemTypeId { get; set; }

        public virtual DdnonmrpitemTypeSetup MrpitemType { get; set; }
    }
}
