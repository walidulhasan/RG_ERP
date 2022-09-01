using System;
using System.Collections.Generic;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class IcUserRole
    {
        public int Id { get; set; }
        public int? RoleId { get; set; }
        public int? UserId { get; set; }
    }
}
