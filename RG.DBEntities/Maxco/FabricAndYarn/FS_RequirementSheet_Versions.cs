using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RG.DBEntities.Maxco.FabricAndYarn
{
    public class FS_RequirementSheet_Versions
    {
        [Key]
        public long RSVID { get; set; }
        public string RSSource { get; set; }
        public long? REQID { get; set; }
        public long? StyleID { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? DeletionDate { get; set; }
        public int? creationuser { get; set; }
    }
}
