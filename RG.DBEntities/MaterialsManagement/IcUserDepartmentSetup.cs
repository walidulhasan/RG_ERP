using System;
using System.Collections.Generic;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class IcUserDepartmentSetup
    {
        public int Id { get; set; }
        public int? DepartmentId { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? ModifyDate { get; set; }
        public int? UserId { get; set; }
    }
}
