using System;

namespace RG.DBEntities.MaterialsManagement.Setup
{
    public class IC_UserDepartmentSetup
    {
        public int Id { get; set; }
        public int? DepartmentId { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? ModifyDate { get; set; }
        public int? UserId { get; set; }
        public int? AuthUserId { get; set; }
        public bool? IsRemoved { get; set; }
    }
}
