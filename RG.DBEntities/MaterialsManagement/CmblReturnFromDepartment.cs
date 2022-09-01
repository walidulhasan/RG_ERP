using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class CmblReturnFromDepartment
    {
        [Key]
        public long Rfdid { get; set; }
        public long Rfdno { get; set; }
        public long CompanyId { get; set; }
        public long UserId { get; set; }
        public int Deleted { get; set; }
        public string Rpname { get; set; }
        public string Comments { get; set; }
        public DateTime Rfddate { get; set; }
    }
}
