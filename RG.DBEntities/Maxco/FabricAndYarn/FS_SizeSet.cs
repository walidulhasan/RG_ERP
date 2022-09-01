using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RG.DBEntities.Maxco.FabricAndYarn
{
    public class FS_SizeSet
    {
        public long ID { get; set; }
        [ForeignKey("FS_ColorSet")]
        public long FS_ColorSetID { get; set; }
        public long SizeSetID { get; set; }
        public int? Quantity { get; set; }
        public string Description { get; set; }
        public virtual FS_ColorSet FS_ColorSet { get; set; }
    }
}
