using System;
using System.Collections.Generic;
using System.Text;

namespace RG.DBEntities.Maxco.FabricAndYarn
{
 public   class FC_FabricGroupUse
    {
        public FC_FabricGroupUse()
        {
            FCModelFabricGroups = new HashSet<FC_ModelFabricGroups>();
        }

        public int GroupID { get; set; }
        public decimal Use { get; set; }
        public long StyleID { get; set; }
        public long ID { get; set; }

        public virtual ICollection<FC_ModelFabricGroups> FCModelFabricGroups { get; set; }
    }
}
