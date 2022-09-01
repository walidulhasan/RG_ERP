using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RG.DBEntities.Maxco.FabricAndYarn
{
  public  class FC_ModelFabricGroups
    {
        public long ID { get; set; }
        [ForeignKey("FC_FabricGroupUse")]
        public long GroupUseID { get; set; }
        [ForeignKey("FabricSpecification")]
        public long FabricID { get; set; }

        public virtual FabricSpecification FabricSpecification { get; set; }
        public virtual FC_FabricGroupUse FC_FabricGroupUse { get; set; }
    }
}
