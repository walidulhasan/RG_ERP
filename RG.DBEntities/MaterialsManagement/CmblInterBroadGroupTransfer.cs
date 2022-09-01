using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class CmblInterBroadGroupTransfer
    {
        [Key]
        public long Ibgid { get; set; }
        public long Ibgno { get; set; }
        public DateTime Ibgdate { get; set; }
        public long CompanyId { get; set; }
        public int Deleted { get; set; }
        public int UserId { get; set; }
        public string Comments { get; set; }
    }
}
