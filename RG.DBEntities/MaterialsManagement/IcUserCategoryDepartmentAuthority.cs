using System;
using System.Collections.Generic;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class IcUserCategoryDepartmentAuthority
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public int? CategoryId { get; set; }
        public int? DepartmentId { get; set; }
        public int? AuthorityId { get; set; }
        public int? AuthorizedBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? ModifyDate { get; set; }
        public int? IsDeleted { get; set; }
    }
}
