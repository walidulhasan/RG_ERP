using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class CottonItemRequisitionMaster
    {
        [Key]
        public long Irid { get; set; }
        public string Ircode { get; set; }
        public DateTime CreationDate { get; set; }
        public string UserId { get; set; }
        public string Status { get; set; }
        public string CreatorComments { get; set; }
    }
}
