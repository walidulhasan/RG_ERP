using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RG.DBEntities.Maxco.FabricAndYarn
{
    public class FS_Fabric_Details
    {
        public int ID { get; set; }
        [ForeignKey("FS_RequirementSheet_Fabrics")]
        public int FID { get; set; }
        public int? FabricID { get; set; }
        public int? ColorSetID { get; set; }
        public int? ShellColorSetId { get; set; }
        public int? SizeSetID { get; set; }
        public int? TrimID { get; set; }

        public virtual FS_RequirementSheet_Fabrics FS_RequirementSheet_Fabrics { get; set; }
    }
}
