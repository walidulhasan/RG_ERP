using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class CmblUserDepartment
    {
        [Key]
        public int UserId { get; set; }
        public int CostCenterId { get; set; }
        public int ActivityId { get; set; }
        public string UserName { get; set; }
        public int? CompanyId { get; set; }
        public int? StoreId { get; set; }
    }
}
