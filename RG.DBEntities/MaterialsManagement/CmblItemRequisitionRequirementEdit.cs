using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class CmblItemRequisitionRequirementEdit
    {
        [Key]
        public long StCsId { get; set; }
        public long? Irrid { get; set; }
        public long? Costid { get; set; }
        public long? Userid { get; set; }
        public DateTime? Creationdate { get; set; }
        public long? Depid { get; set; }
        public int? DocumnetType { get; set; }
    }
}
