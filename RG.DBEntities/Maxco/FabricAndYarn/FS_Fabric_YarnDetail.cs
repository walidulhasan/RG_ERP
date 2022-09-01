using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RG.DBEntities.Maxco.FabricAndYarn
{
    public class FS_Fabric_YarnDetail
    {

        public int ID { get; set; }
        [ForeignKey("FS_RequirementSheet_Fabrics")]
        public int FID { get; set; }
        public long AttributeinstanceID { get; set; }
        public double Utilization { get; set; }
         public virtual FS_RequirementSheet_Fabrics FS_RequirementSheet_Fabrics { get; set; }
    }
}
